using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Susie
{
    class Schedule
    {        
        private DataContext dataContext;
        public Table<Load> Loads;
        public Table<AtomLesson> Atoms;
        public List<Lesson> Lessons;
        public List<AtomLesson> LocalAtoms;
        private BindingSource lessonBind;
        private int semester;

        private System.Threading.Thread process;  // окремий потік для splash screen 

        public Schedule(DataContext dataContext)
        {
            this.dataContext = dataContext;
            LocalAtoms = new List<AtomLesson>();
            Lessons = new List<Lesson>();
            lessonBind = new BindingSource();
            Load();
        }
        public DataContext DataContext
        {
            set { dataContext = value; }
        }
        public BindingSource LessonBind
        {
            get { return lessonBind; }
        }

        public void Update()
        {
            dataContext.ExecuteCommand("DELETE FROM Schedule");
            dataContext.SubmitChanges();
            foreach (AtomLesson a in GetAllAtoms())
            {
                dataContext.ExecuteCommand(a.GetQuery("Schedule"));
            }
            dataContext.SubmitChanges();
        }

        public List<Lesson> GetLessons()
        {
            return Lessons.Where(l => l.Semester == semester).ToList<Lesson>();
        }

        public void Load()
        {
            process = new System.Threading.Thread(NewForm);
            process.Start();

            semester = 0;
            Program.Specialitys = dataContext.GetTable<Speciality>();
            Program.Classrooms = dataContext.GetTable<Classroom>();
            Program.Teachers = dataContext.GetTable<Teacher>();
            Atoms = dataContext.GetTable<AtomLesson>();
            Program.Subjects = dataContext.GetTable<Subject>();
            Program.Groups = dataContext.GetTable<Group>();
            Loads = dataContext.GetTable<Load>();

            Lessons = MakeLessons();
            ChangeSemester();

            process.Abort();
        }

        public void AddLesson(Lesson L)
        {
            L.Semester = Semester;
            if (!L.IsNormal())
            {
                L.RollBack();
                throw new Exception("Дані не реальні");
            }
            if (!Check(L))
            {
                L.RollBack();
                throw new Exception("Перевищення годин  в навантаженні");
            }
            if (L.Message() != "")
                if (MessageBox.Show(L.Message(), "Додати?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    L.RollBack();
                    return;
                }
            Lessons.Add(L);
        }

        private bool Check(Lesson L)
        {
            foreach (Teacher t in L.Teachers)
            {
                foreach (Group g in L.Groups)
                    if (t.CountOfHours(L, g) > LoadHours(t,g))
                        return false;
            }
            return true;
        }

        int LoadHours(Teacher T, Group G)
        {
            Load load = new Load();
            foreach (Load l in this.Loads)
            {
                if ((l.Teacher == T) && (l.Group == G) && (l.Semester == this.Semester))
                {
                    load = l;
                    break;
                }
            }
            return load.WeeklyHour;
        }

        public void RemoveLessons(Lesson L)
        {
            Lessons.Remove(L);
            foreach (Group g in L.Groups)
                g.Lessons.Remove(L);
            foreach (Classroom c in L.Classrooms)
                c.Lessons.Remove(L);
            foreach (Teacher t in L.Teachers)
                t.Lessons.Remove(L);
            lessonBind.Remove(L);
        }

        private List<Lesson> MakeLessons()
        {
            if (Atoms.Count() == 0)
                return new List<Lesson>();
            List<AtomLesson> baseAtoms = Atoms.ToList<AtomLesson>();
            List<Lesson> lessons = new List<Lesson>();
            List<Boolean> flags = new List<bool>();
            List<Lesson> outlist = new List<Lesson>();
            foreach (AtomLesson a in baseAtoms)
            {
                lessons.Add(LessonFromAtom(a));
                flags.Add(true);
            }
            for (int i = 0; i < lessons.Count(); i++)
            {
                if (!flags[i]) continue;
                for (int j = 0; j < lessons.Count(); j++)
                    if ((lessons[i] != lessons[j]) && (lessons[i].Compare(lessons[j])))
                    {
                        lessons[i].Union(lessons[j]);
                        flags[j] = false;
                    }
                outlist.Add(lessons[i]);
            }
            return outlist;
        }

        private Lesson LessonFromAtom(AtomLesson atom)
        {
            Lesson l = new Lesson();
            l.Day = atom.Day;
            l.Type = atom.Type;
            l.Number = atom.Number;
            l.Semester = atom.Semester;
            l.AddGroup(Program.Groups.Where(g => g.ID == atom.GroupID).ToList().First());
            l.AddTeacher(Program.Teachers.Where(t => t.ID == atom.TeacherID).ToList().First());
            l.AddClassroom(Program.Classrooms.Where(c => c.ID == atom.ClassroomID).ToList().First());
            l.Subject = (Program.Subjects.Where(s => s.ID == atom.SubjectID)).ToList<Subject>().First();
            return l;
        }

        public int Semester
        {
            get { return semester; }
            set 
            { 
                semester = value;
                ChangeSemester();
            }
        }

        private void ChangeSemester()
        {
            lessonBind.DataSource = Lessons.Where(l => l.Semester == Semester);
        }

        public void GetFormSchedule(Teacher T)
        {
            if (T == null) return;
            ScheduleView form = new ScheduleView();
            form.Text = T.Title;
            List<Lesson> query = (from l in Lessons
                                  where T.IsMember(l.Teachers) && (l.Semester == semester)
                                  select l).ToList<Lesson>();
            form.panel1.Controls.Clear();
            foreach (Lesson l in query)
            {
                VisualLesson c = new VisualLesson();
                form.panel1.Controls.Add(c);
                c.Lesson = l;
                c.Mode = ViewMode.ForTeacher;
            }
            form.ShowDialog();
        }
        public void GetFormSchedule(Classroom C)
        {
            if (C == null) return;
            ScheduleView form = new ScheduleView();
            form.Text = C.Title;
            List<Lesson> query = (from l in C.Lessons
                                  where (l.Semester == semester)
                                  select l).ToList<Lesson>();
            form.panel1.Controls.Clear();
            foreach (Lesson l in query)
            {
                VisualLesson c = new VisualLesson();
                form.panel1.Controls.Add(c);
                c.Lesson = l;
                c.Mode = ViewMode.ForClassroom;
            }
            form.ShowDialog();
        }
        public void GetFormSchedule(Group G)
        {
            if (G == null) return;
            ScheduleView form = new ScheduleView();
            form.Text = G.Title;
            List<Lesson> query = (from l in Lessons
                                  where G.IsMember(l.Groups) && (l.Semester == semester)
                                  select l).ToList<Lesson>();

            form.panel1.Controls.Clear();

            foreach (Lesson l in query)
            {
                VisualLesson c = new VisualLesson();
                form.panel1.Controls.Add(c);
                c.Lesson = l;
                c.Mode = ViewMode.ForGroup;
            }

            form.ShowDialog();
        }
        
        public List<AtomLesson> GetAllAtoms()
        {
            AtomLesson.ResetID();
            List<AtomLesson> atoms = new List<AtomLesson>();
            foreach (Lesson l in Lessons)
            {
                atoms.AddRange(l.GetAtoms());
            }
            return atoms;
        }
       
        public List<Load> GetSemester(List<Load> L)
        {
            if ((L == null) || (L.Count == 0))
            {
                return new List<Load>(0);
            }
            return L.Where(l => l.Semester == this.semester).ToList();
        }
        public List<Group> GetGroups(int Course, Speciality S)
        {
            return S.Groups.Where(g => g.Course == Course).ToList<Group>();
        }
        public List<Lesson> GetLessonsForGroups(List<Group> G)
        {
            if ( (G == null) || (G.Count() == 0))
                return new List<Lesson>();
            List<Lesson> lessons = new List<Lesson>();
            foreach (Lesson l in G[0].Lessons)
            {
                bool b = true;
                foreach (Group g in G)
                    if ((g.Lessons.IndexOf(l) == -1) || (l.Semester != this.semester))
                    {
                        b = false;
                        break;
                    }
                if (b) lessons.Add(l);
            }
            return lessons;
        }
        public List<Subject> GetSubjectsForGroup(Group G)
        {
            if (G == null)
                return new List<Subject>();
            EntitySet<Subject> subjects = new EntitySet<Subject>();
            var query = from s in G.Loads.Where(l => l.Semester == semester)
                        select s.Subject;
            foreach (Subject s in query)
                subjects.Add(s);
            return subjects.ToList<Subject>();
        }
        public List<Teacher> GetTeachersFor(List<Group> G, Subject S, int Lab)
        {
            if ((G.Count() == 0) || (S == null) || (Lab == -1) || ((G.Count() > 1) && (Lab == 1)))
                return new List<Teacher>();
            List<Teacher> teachers = new List<Teacher>();
            List<Load> tmp;
            if (Lab == 0)
                tmp = G[0].Loads.Where(l => l.IsLecture).ToList();
            else
                tmp = G[0].Loads.Where(l => l.IsLab).ToList();
            var query = from l in tmp
                        where (l.Subject == S) && (l.Semester == this.semester)
                        select l.Teacher;
            teachers.AddRange(query);
            return teachers;
        }
        public List<Lesson> GetLessonsForTeachers(List<Teacher> T)
        {
            if ((T == null) || (T.Count() == 0))
                return new List<Lesson>();
            List<Lesson> lessons = new List<Lesson>();
            foreach (Lesson l in T[0].Lessons)
            {
                bool b = true;
                foreach (Teacher g in T)
                    if ((g.Lessons.IndexOf(l) == -1) || (l.Semester != this.semester))
                    {
                        b = false;
                        break;
                    }
                if (b) lessons.Add(l);
            }
            return lessons;
        }
        public List<Lesson> GetLessonsForClassrooms(List<Classroom> C)
        {
            if ((C == null) || (C.Count() == 0))
                return new List<Lesson>();
            List<Lesson> lessons = new List<Lesson>();
            foreach (Lesson l in C[0].Lessons)
            {
                bool b = true;
                foreach (Classroom g in C)
                    if ((g.Lessons.IndexOf(l) == -1) || (l.Semester != this.semester))
                    {
                        b = false;
                        break;
                    }
                if (b) lessons.Add(l);
            }
            return lessons;
        }
        //SplashScreen
        private void NewForm()
        {
            SplashScreen form = new SplashScreen();
            form.ShowDialog();
        }
        // Excel
        const String ExcelTemplatePath = @"C:\book1.xls";
        public void GetExcelSchedule(List<Group> G)
        {
            if (G.Count == 0) return;

            Excel.Application excelApp = new Excel.Application();

            Excel.Workbooks excelAppWorkBooks = excelApp.Workbooks;
            Excel.Workbook excelAppWorkBook = excelApp.Workbooks.Open(ExcelTemplatePath,
                              Type.Missing, Type.Missing, Type.Missing,
                             "WWWWW", "WWWWW", Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing);

            Excel.Sheets excelSheets = excelAppWorkBook.Worksheets;
            Excel.Worksheet WorkSheet = (Excel.Worksheet)excelSheets[1];
            for (int i = 0; i < G.Count; i++)
                WriteSchedule(G[i], WorkSheet, i);
            excelApp.Visible = true;
            
        }
        public void GetExcelSchedule(Teacher T)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbooks excelAppWorkBooks = excelApp.Workbooks;
            Excel.Workbook excelAppWorkBook = excelApp.Workbooks.Open(ExcelTemplatePath,
                              Type.Missing, Type.Missing, Type.Missing,
                             "WWWWW", "WWWWW", Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing);

            Excel.Sheets excelSheets = excelAppWorkBook.Worksheets;
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheets[1];
            int n = 4;
            var excelCell = (Excel.Range)excelWorkSheet.Cells[1, n];
            excelCell.Value2 = T.Title;
            excelCell.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = "3";
            excelCell.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = "3";

            foreach (Lesson l in T.Lessons.Where(l => l.Semester == semester).ToList())
            {
                int m = l.Day * 16 + l.Number * 4 + 2;
                int offset = 0;
                int shift = 0;
                if (l.Type != 0)
                {
                    offset = 1;
                    excelCell = (Excel.Range)excelWorkSheet.Cells[m + 1, n];
                    excelCell.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = "3";
                    if (l.Type != 1) shift = 2;

                }
                excelCell = (Excel.Range)excelWorkSheet.Cells[m + shift, n];
                excelCell.Value2 = l.TitleSubject;
                excelCell = (Excel.Range)excelWorkSheet.Cells[m + 2 - offset + shift, n];
                excelCell.Value2 += l.TitleGroups + " ";
                excelCell.Value2 += l.TitleClassrooms;
            }
            excelApp.Visible = true;
        }
        public void GetExcelSchedule(Classroom C)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbooks excelAppWorkBooks = excelApp.Workbooks;
            Excel.Workbook excelAppWorkBook = excelApp.Workbooks.Open(ExcelTemplatePath,
                              Type.Missing, Type.Missing, Type.Missing,
                             "WWWWW", "WWWWW", Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing);

            Excel.Sheets excelSheets = excelAppWorkBook.Worksheets;
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheets[1];

            int n = 4;
            var excelCell = (Excel.Range)excelWorkSheet.Cells[1, n];
            excelCell.Value2 = C.Title;
            excelCell.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = "3";
            excelCell.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = "3";

            foreach (Lesson l in C.Lessons.Where(l => l.Semester == semester).ToList())
            {
                int m = l.Day * 16 + l.Number * 4 + 2;
                int offset = 0;
                int shift = 0;
                if (l.Type != 0)
                {
                    offset = 1;
                    excelCell = (Excel.Range)excelWorkSheet.Cells[m + 1, n];
                    excelCell.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = "3";
                    if (l.Type != 1) shift = 2;

                }
                excelCell = (Excel.Range)excelWorkSheet.Cells[m + shift, n];
                excelCell.Value2 = l.TitleSubject;
                excelCell = (Excel.Range)excelWorkSheet.Cells[m + 2 - offset + shift, n];
                excelCell.Value2 += l.TitleGroups + " ";
                excelCell.Value2 += l.TitleTeachers;
            }
            excelApp.Visible = true;
        }

        private void WriteSchedule(Group G, Excel.Worksheet WorkSheet, int position)
        {
            int n = 4 + position;
            char C = (char)(100 + position);

            var excelCell = (Excel.Range)WorkSheet.Cells[1, n];
            excelCell.Value2 = G.Title;
            excelCell.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = "3";
            excelCell.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = "3";
            for (int i = 1; i <= 80; i += 4)
            {
                excelCell = WorkSheet.get_Range(C + (i + 1).ToString(), C + (i + 4).ToString());
                excelCell.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = "3";
                excelCell.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = "3";
            }
            foreach (Lesson l in G.Lessons.Where(l => l.Semester == semester).ToList())
            {
                int m = l.Day * 16 + l.Number * 4 + 2;
                int offset = 0;
                int shift = 0;
                if (l.Type != 0)
                {
                    offset = 1;
                    excelCell = (Excel.Range)WorkSheet.Cells[m + 1, n];
                    excelCell.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = "3";
                    if (l.Type != 1) shift = 2;
                }
                excelCell = (Excel.Range)WorkSheet.Cells[m + shift, n];
                excelCell.Value2 = l.TitleSubject;
                for (int i = 0; i < l.Teachers.Count(); i++)
                {
                    excelCell = (Excel.Range)WorkSheet.Cells[m + 2 - offset + shift, n];
                    excelCell.Value2 += l.Teachers[i].FullName() + " ";
                    excelCell.Value2 += l.Classrooms[i].Title + " ";
                }
            }
        }
    }
}
