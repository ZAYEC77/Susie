using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Susie
{
    class Lesson
    {
        private EntitySet<Group> groups;
        private EntitySet<Teacher> teachers;
        private EntitySet<Classroom> classrooms;
        private Subject subject;
        private int day;
        private int number;
        private int type;
        private int semester;
        private string message;

        public Lesson()
        {
            groups = new EntitySet<Group>();
            teachers = new EntitySet<Teacher>();
            classrooms = new EntitySet<Classroom>();
            message = "";
        }

        public Subject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public List<Group> Groups
        {
            get { return groups.ToList<Group>(); }
            set { groups.Assign(value); }
        }
        public List<Teacher> Teachers
        {
            get { return teachers.ToList<Teacher>(); }
            set { teachers.Assign(value); }
        }
        public List<Classroom> Classrooms
        {
            get { return classrooms.ToList<Classroom>(); }
            set { classrooms.Assign(value); }
        }
        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Number
        {
            get { return number; }
            set
            {
                if (number == value)
                    return;
                number = value;
                if ((value < 0) || (value > 4)) throw new Exception("Виберіть номер заняття");
            }
        }
        public int DayOfWeek
        {
            get { return day; }
            set
            {
                if (day == value)
                    return;
                day = value;
                if ((value < 0) || (value > 6)) throw new Exception("Виберіть день заняття");
            }
        }
        public int Semester
        {
            get { return semester; }
            set { semester = value; }
        }
        public string DayName
        {
            get
            {
                switch (day)
                {
                    case 0: return "Понеділок";
                    case 1: return "Вівторок";
                    case 2: return "Середа";
                    case 3: return "Четвер";
                    case 4: return "П'ятниця";
                }
                return "Субота";
            }
        }
        public int IncDay
        {
            get { return day + 1; }
        }

        public bool IsNormal()
        {
            if ((subject == null) || (groups.Count() == 0) || (teachers.Count() == 0) || (classrooms.Count() == 0))
                return false;
            if ((groups.Count() > 1) && (teachers.Count() > 1))
                return false;
            if ((teachers.Count() > 1) && (classrooms.Count() == 1))
                return false;
            if ((teachers.Count() == 1) && (classrooms.Count() > 1))
                return false;
            return true;
        }
        public void Union(Lesson L)
        {
            AddGroups(L.Groups);
            AddClassrooms(L.Classrooms);
            AddTeachers(L.Teachers);
            foreach (Group g in groups)
                g.Lessons.Remove(L);
            foreach (Teacher t in teachers)
                t.Lessons.Remove(L);
            foreach (Classroom c in classrooms)
                c.Lessons.Remove(L);
            message = "";
        }

        public bool Compare(Lesson L)
        {
            if ((this.day == L.day) && (this.number == L.number) && (this.subject == L.subject) && (this.semester == L.semester))
                return true;
            else
                return false;
        }
        public bool Conflict(Lesson L)
        {
            if ((this.day == L.day) && (this.number == L.number) && (this.semester == L.semester))
                return true;
            else
                return false;
        }
        public string Message()
        {
            return message;
        }
        public void RollBack()
        {
            foreach (Teacher t in teachers)
                t.Lessons.Remove(this);
            foreach (Group g in groups)
                g.Lessons.Remove(this);
            foreach (Classroom c in classrooms)
                c.Lessons.Remove(this);
        }

        public void AddGroups(List<Group> Gs)
        {
            foreach(Group g in Gs)
            {
                AddGroup(g);
            }
        }
        public void AddTeachers(List<Teacher> Ts)
        {
            foreach(Teacher t in Ts)
            {
                AddTeacher(t);
            }
        }
        public void AddClassrooms(List<Classroom> Cs)
        {
            foreach (Classroom c in Cs)
            {
                AddClassroom(c);
            }
        }

        public void AddGroup(Group G)
        {
            foreach (Lesson l in G.Lessons)
                if (l.Conflict(this))
                {
                    message += "Група " + G.Title + " занята\n";
                    break;
                }
            groups.Add(G);
            G.Lessons.Add(this);
        }
        public void AddTeacher(Teacher T)
        {
            foreach (Lesson l in T.Lessons)
                if (l.Conflict(this))
                {
                    message += "Викладач " + T.Title + " занятий(-a)\n";
                    break;
                }
            teachers.Add(T);
            T.Lessons.Add(this);
        }
        public void AddClassroom(Classroom C)
        {
            foreach (Lesson l in C.Lessons)
                if (l.Conflict(this))
                {
                    message += "Аудиторія " + C.Title + " занята\n";
                    break;
                }
            classrooms.Add(C);
            C.Lessons.Add(this);
        }

        public string Title
        {
            get { return DayName + ((Number + 1) * 2 - 1).ToString() + '-' + ((Number + 1) * 2).ToString() + TitleGroups + subject.Title + TitleTeachers + TitleClassrooms; }
        }
        public string ShortTitle
        {
            get { return TitleGroups + "  " + subject.Title + "  " + TitleTeachers + "  " + TitleClassrooms; }
        }

        public string TitleNumber
        {
            get { return ((Number + 1) * 2 - 1).ToString() + '-' + ((Number + 1) * 2).ToString(); }
        }
        public string TitleSubject
        {
            get { return (subject.Title == null) ? "Немає заняття" : subject.Title; }
        }
        public string TitleGroups
        {
            get
            {
                string s = "";
                foreach (Group g in groups)
                {
                    s += g.Title + " ";
                }
                return s;
            }
        }
        public string TitleClassrooms
        {
            get
            {
                string s = "";
                foreach (Classroom c in classrooms)
                {
                    s += c.Title + " ";
                }
                return s.Remove(s.Length - 1);
            }
        }
        public string TitleTeachers
        {
            get
            {
                string s = "";
                foreach (Teacher t in teachers)
                {
                    s += t.FullName() + " ";
                }

                return s.Remove(s.Length - 1);
            }
        }
        public string TitleGroupsInColumn
        {
            get
            {
                string s = "";
                foreach (Group g in groups)
                {
                    s += g.Title + "\n";
                }
                return s;
            }
        }
        public string TitleClassroomsInColumn
        {
            get
            {
                string s = "";
                foreach (Classroom c in classrooms)
                {
                    s += c.Title + "\n";
                }
                return s.Remove(s.Length - 1);
            }
        }
        public string TitleTeachersInColumn
        {
            get
            {
                string s = "";
                foreach (Teacher t in teachers)
                {
                    s += t.FullName() + "\n";
                }

                return s.Remove(s.Length - 1);
            }
        }
        public List<AtomLesson> GetAtoms()
        {
            if (groups.Count > 1)
                return GetAtomsForGroups();
            else
            {
                return GetAtomsForTeachers();
            }
        }

        public void ShowInformation()
        {
            MessageBox.Show(
                "Предмет: " + TitleSubject + '\n' +
                "Групи: " + TitleGroups + '\n' +
                "Викладачі: " + TitleTeachers + '\n' +
                "Аудиторії: " + TitleClassrooms,
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public int CountOfHours(List<Lesson> L)
        {
            List<Lesson> query = (from l in L
                                  where ((l.subject == this.subject)&&(l.semester == this.semester))
                                  select l).ToList();
            int count = 0;
            foreach (Lesson l in query)
            {
                
                if (l.Type == 0)
                    count += 2;
                else
                    count += 1;
            }
            return count;
        }

        private List<AtomLesson> GetAtomsForGroups()
        {
            List<AtomLesson> atoms = new List<AtomLesson>();
            for (int i = 0; i < groups.Count; i++)
            {
                AtomLesson atom = GetAtom();
                atom.SubjectID = subject.ID;
                atom.GroupID = groups[i].ID;
                atom.TeacherID = teachers[0].ID;
                atom.ClassroomID = classrooms[0].ID;
                atoms.Add(atom);
            }
            return atoms;
        }
        private List<AtomLesson> GetAtomsForTeachers()
        {
            List<AtomLesson> atoms = new List<AtomLesson>();
            for (int i = 0; i < teachers.Count; i++)
            {
                AtomLesson atom = GetAtom();
                atom.SubjectID = subject.ID;
                atom.GroupID = groups[0].ID;
                atom.TeacherID = teachers[i].ID;
                atom.ClassroomID = classrooms[i].ID;
                atoms.Add(atom);
            }
            return atoms;
        }
        private AtomLesson GetAtom()
        {
            AtomLesson atom = new AtomLesson();
            atom.Number = number;
            atom.Type = type;
            atom.Day = day;
            atom.Semester = semester;
            return atom;
        }

    }

}
