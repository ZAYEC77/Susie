using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Susie
{
    class Replacement
    {
        private DataContext dataContext;

        private List<Lesson> schedule;
        public Lesson selectedLesson;
        private EntitySet<Lesson> haveReplacement;
        private List<Lesson> currentReplacements;
        private List<Lesson> replacements;
        public List<AtomLesson> AtomReplacements;

        private List<Lesson> fact;
        public BindingSource FactBind;

        private int day = 0;
        private int type = 1; 
        private string message;

        public Replacement(DataContext dataContext)
        {
            this.dataContext = dataContext;
            replacements = new List<Lesson>();
            fact = new List<Lesson>();
            FactBind = new BindingSource();
            FactBind.DataSource = fact;
            haveReplacement = new EntitySet<Lesson>();
            currentReplacements = new List<Lesson>();
        }
     
        public int Day
        {
            get { return day; }
            set 
            { 
                day = value; 
                RefreshFact(); 
            }
        }
        public bool Type
        {
            get { return type == 1; }
            set
            {
                if (value)
                    type = 1;
                else
                    type = 2;
                RefreshFact();
            }
        }
        public string Message
        {
            get
            {
                string tmp = message;
                message = "";
                return tmp;
            }

        }
        public void RollBack()
        {
            haveReplacement.Remove(selectedLesson);
            foreach (Lesson l in currentReplacements)
                replacements.Remove(l);
        }
        public bool AddReplacemant(List<Group> G, List<Teacher> T, List<Classroom> C, Subject S)
        {
            if (selectedLesson == null)
            {
                throw new Exception("Немає заняття, що замінюється");
            }
            haveReplacement.Add(selectedLesson);
            Lesson les = new Lesson{ 
                Day = this.day, 
                Number = this.selectedLesson.Number, 
                Type = this.selectedLesson.Type};
            les.Subject = S;
            message = "";
            RefreshFact();
            foreach (Group g in G)
            {
                var query = fact.
                    Where(l => l.Groups.IndexOf(g) != -1).
                    Where(l => l.Number == les.Number);
                if (query.Count() > 0)
                    message += g.Title + " ";
            }
            foreach (Teacher t in T)
            {
                var query = fact.
                    Where(l => l.Teachers.IndexOf(t) != -1).
                    Where(l => l.Number == les.Number);
                if (query.Count() > 0)
                    message += t.FullName() + " ";
            }
            foreach (Classroom c in C)
            {
                var query = fact.
                    Where(l => l.Classrooms.IndexOf(c) != -1).
                    Where(l => l.Number == les.Number);
                if (query.Count() > 0)
                    message += c.Title + " ";
            }

            if (message != "")
            {
                message = "Зайняті: " + message;
                return false;
            }
            les.Groups = G;
            les.Teachers = T;
            les.Classrooms = C;
            if (!les.IsNormal())
            {
                message = "Помилка";
                return false;
            }
            replacements.Add(les);
            currentReplacements.Add(les);

            return true;
        }
        public void RemoveReplacemant(Lesson L)
        {
            replacements.Remove(L);
            EntitySet<Lesson> query = new EntitySet<Lesson>();
            foreach (Group g in L.Groups)
                query.AddRange(
            haveReplacement.
                Where(r => r.Day == L.Day).
                Where(r => r.Number == L.Number).
                Where(r => r.Groups.Contains(g))
                );
            foreach (Lesson l in query)
                haveReplacement.Remove(l);
            RefreshFact();
        }
        public List<Lesson> Replacements
        {
            get { return replacements.Where(l => l.Day == day).Where(l => l.Type == type).ToList(); }
        }
        public void SubmitChanges()
        {
            dataContext.ExecuteCommand("DELETE FROM Replacement");
            dataContext.SubmitChanges();
            foreach (Lesson l in replacements)
            {
                foreach (AtomLesson a in l.GetAtoms())
                    dataContext.ExecuteCommand(a.GetQuery("Replacement"));
            }
            dataContext.SubmitChanges();
        }
        public void Load()
        {
            AtomReplacements = GetReplacementsAtoms();
            replacements = MakeReplacement();
        }
        public List<AtomLesson> GetReplacementsAtoms()
        {
            List<AtomLesson> list = new List<AtomLesson>();
            OleDbDataAdapter adapter = new OleDbDataAdapter(
                "SELECT * FROM Replacement",
                dataContext.Connection as OleDbConnection);

            DataTable table = new DataTable();
            adapter.Fill(table);
            var tmp = table.Select();
            foreach (DataRow row in tmp)
            {
                AtomLesson a = new AtomLesson
                {
                    ID = Convert.ToInt32(row[0]),
                    GroupID = Convert.ToInt32(row[1]),
                    ClassroomID = Convert.ToInt32(row[2]),
                    SubjectID = Convert.ToInt32(row[3]),
                    TeacherID = Convert.ToInt32(row[4]),
                    Number = Convert.ToInt32(row[5]),
                    Day = Convert.ToInt32(row[6]),
                    Type = Convert.ToInt32(row[7]),
                    Semester = Convert.ToInt32(row[8])
                };
                list.Add(a);
            }
            return list;
        }
        public List<Lesson> Schedule
        {
            set {
                schedule = value;
                RefreshFact();
            }
        }

        public bool IsReplacement(Lesson L)
        {
            return schedule.IndexOf(L) == -1;
        }
        List<Lesson> MakeReplacement()
        {
            if (AtomReplacements.Count() == 0)
                return new List<Lesson>();
            List<Lesson> lessons = new List<Lesson>();
            List<Boolean> flags = new List<bool>();
            List<Lesson> outlist = new List<Lesson>();
            foreach (AtomLesson a in AtomReplacements)
            {
                Lesson l = new Lesson();
                l.Type = a.Type;
                l.Number = a.Number;
                l.Groups = Program.Groups.Where(g => g.ID == a.GroupID).ToList<Group>();
                l.Teachers = Program.Teachers.Where(t => t.ID == a.TeacherID).ToList<Teacher>();
                l.Classrooms = Program.Classrooms.Where(c => c.ID == a.ClassroomID).ToList<Classroom>();
                var su = Program.Subjects.Where(s => s.ID == a.SubjectID).ToList<Subject>();
                l.Subject = su[0];
                l.Day = a.Day;
                l.Semester = a.Semester;
                var query = schedule.
                        Where(s => s.Groups.IndexOf(l.Groups[0]) != -1).
                        Where(s => s.Day == l.Day).
                        Where(s => s.Type == l.Type).
                        Where(s => s.Number == l.Number).
                        ToList<Lesson>();
                haveReplacement.AddRange(query);
                lessons.Add(l);
                flags.Add(true);
            }
            List<Lesson> less = new List<Lesson>();
            for (int i = 0; i < lessons.Count(); i++)
            {
                if (!flags[i]) continue;
                for (int j = 0; j < lessons.Count(); j++)
                    if ((lessons[i] != lessons[j]) && 
                        lessons[i].Compare(lessons[j]) && 
                        ( (lessons[i].Teachers[0] == lessons[j].Teachers[0]) || 
                        (lessons[i].Groups[0] == lessons[j].Groups[0])))
                    {
                        if (lessons[i].Groups[0] != lessons[j].Groups[0])
                        {
                            var tmp = lessons[i].Groups;
                            tmp.Add(lessons[j].Groups[0]);
                            lessons[i].Groups = tmp;
                        }
                        if (lessons[i].Teachers[0] != lessons[j].Teachers[0])
                        {
                            var tmp = lessons[i].Teachers;
                            tmp.Add(lessons[j].Teachers[0]);
                            lessons[i].Teachers = tmp;
                            var tmp2 = lessons[i].Classrooms;
                            tmp2.Add(lessons[j].Classrooms[0]);
                            lessons[i].Classrooms = tmp2;
                        }
                        flags[j] = false;
                    }
                less.Add(lessons[i]);
            }

            return less;
        }

        public void RefreshFact()
        {

            fact.Clear();
            List<Lesson> tmp = schedule.
                Where(l => l.Day == day).
                Where(l => l.Type != type).
                ToList(); 
            foreach (Lesson f in tmp)
            {
                if (haveReplacement.IndexOf(f) == -1)
                    fact.Add(f);
            }
            fact.AddRange(replacements.
                Where(l => l.Day == day).
                Where(l => l.Type != type).
                ToList()); 
            FactBind.DataSource = null;
            FactBind.DataSource = fact;
        }
        public List<Lesson> CurrentReplacements
        {
            get { return currentReplacements; }
        }

        public void ShowFor(Group G)
        {
            RefreshFact();
            FactBind.DataSource = fact.
                Where(l => l.Groups.IndexOf(G) != -1).
                ToList();
        }
        public void ShowFor(Teacher T)
        {
            RefreshFact();
            FactBind.DataSource = fact.
                Where(l => l.Teachers.IndexOf(T) != -1).
                ToList();
        }
        public void ShowAll()
        {
            FactBind.DataSource = fact;
        }

        public void ExportInWord(DateTime date)
        {
             List<Lesson> list = replacements.
                Where(l => l.Day == day).
                Where(l => l.Type != type).
                ToList();
            if (list.Count == 0)
            {
                MessageBox.Show("Заміни порожні");
                return;
            }

            int rows = list.Count + 1;
            Word.Application app = new Word.Application();
            object oMissing = System.Reflection.Missing.Value;
            Word.Document doc = app.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            Word.Selection selection = app.Selection; 
			int cols = 5;
 
            selection.Paragraphs[1].Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            selection.TypeText("Заміни в розкладі на " + date.Date.ToShortDateString() + '\n' + list[0].DayName + "  - ");
            if (type == 1)
                selection.TypeText("Чисельник\n");
            else
                selection.TypeText("Знаменник\n");

			// додаємо табличку
			Word.Table table = doc.Tables.Add(selection.Range, rows, cols, ref oMissing, ref oMissing);
			// обхід таблички циклом
            table.Cell(1, 1).Select();
            selection.TypeText("Група");
            table.Cell(1, 2).Select();
            selection.TypeText("№");
            table.Cell(1, 3).Select();
            selection.TypeText("Предмет");
            table.Cell(1, 4).Select();
            selection.TypeText("Викладач");
            table.Cell(1, 5).Select();
            selection.TypeText("Аудиторії");
            for (int i = 0; i < list.Count; i++)
            {
                table.Cell(i + 2, 1).Select();
                selection.TypeText(list[i].TitleGroups);
                table.Cell(i + 2, 2).Select();
                selection.TypeText(list[i].TitleNumber);
                table.Cell(i + 2, 3).Select();
                selection.TypeText(list[i].TitleSubject);
                table.Cell(i + 2, 4).Select();
                selection.TypeText(list[i].TitleTeachersInColumn);
                table.Cell(i + 2, 5).Select();
                selection.TypeText(list[i].TitleClassroomsInColumn);
            }

            object unit = Word.WdUnits.wdStory;
			object extend  = Word.WdMovementType.wdMove;
			selection.EndKey(ref unit, ref extend); 

            app.Visible = true;

        }
        private bool IsReplacements()
        {
            return (replacements.Count != 0);
        }
        public Lesson SelectedLesson
        {
            set { selectedLesson = value; }
            get { return selectedLesson; }
        }

        public void WriteFact()
        {
            OleDbCommand cmd = new OleDbCommand("", dataContext.Connection as OleDbConnection);
            dataContext.Connection.Open();
            foreach (Lesson l in fact)
            {
                List<AtomLesson> list = l.GetAtoms();
                foreach (AtomLesson a in list)
                {
                    cmd.CommandText = "INSERT INTO Fact" +
                 "( GroupID, ClassroomID, SubjectID, TeacherID, [Number], [Date] ) " +
                "VALUES (" +
                a.GroupID.ToString() + ',' +
                a.ClassroomID.ToString() + ',' +
                a.SubjectID + ',' +
                a.TeacherID + ',' +
                a.Number.ToString() + ',' + '"' +
                System.DateTime.Now.ToShortDateString() + '"' + ')';
                    cmd.ExecuteNonQuery();
                }
            }
            dataContext.Connection.Close();
        }
    }
}
