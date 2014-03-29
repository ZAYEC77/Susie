using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace Susie
{
    [Table(Name = "Loadings")]
    class Load
    {
        private string _ID = "";
        private int _TeacherID;
        private int _GroupID;
        private int _SubjectID;
        private int _Semester;
        private int _WeeklyHour;
        private int _Lecture;
        private int _Lab;
 
        private EntityRef<Teacher> _Teacher;
        private EntityRef<Group> _Group;
        private EntityRef<Subject> _Subject;

        public Load()
        {
            this._Teacher = new EntityRef<Teacher>();
            this._Group = new EntityRef<Group>();
            this._Subject = new EntityRef<Subject>();
        }

        [Column(IsPrimaryKey = true, Storage = "_ID")]
        public string ID
        {
            get { return this._ID; }
        }

        [Column(Storage = "_TeacherID")]
        public int TeacherID
        {
            get { return this._TeacherID; }
            set { this._TeacherID = value; }
        }

        [Column(Storage = "_SubjectID")]
        public int SubjectID
        {
            get { return this._SubjectID; }
            set { this._SubjectID = value; }
        }

        [Column(Storage = "_GroupID")]
        public int GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        [Association(Storage = "_Group", ThisKey = "GroupID")]
        public Group Group
        {
            get { return this._Group.Entity; }
            set { this._Group.Entity = value; }
        }

        [Association(Storage = "_Teacher", ThisKey = "TeacherID")]
        public Teacher Teacher
        {
            get { return this._Teacher.Entity; }
            set { this._Teacher.Entity = value; }
        }

        [Association(Storage = "_Subject", ThisKey = "SubjectID")]
        public Subject Subject
        {
            get { return this._Subject.Entity; }
            set { this._Subject.Entity = value; }
        }

        [Column(Storage = "_WeeklyHour")]
        public int WeeklyHour
        {
            get { return this._WeeklyHour; }
            set { this._WeeklyHour = value; }
        }

        [Column(Storage = "_Semester")]
        public int Semester
        {
            get { return this._Semester; }
            set { this._Semester = value; }
        }

        public string TitleTeacher
        {
            get { return this._Teacher.Entity.Title; }
        }

        public string TitleGroup
        {
            get { return this._Group.Entity.Title; }
        }

        public string TitleSubject
        {
            get { return this._Subject.Entity.Title; }
        }

        [Column(Storage = "_Lecture")]
        public int Lecture
        {
            get { return this._Lecture; }
            set { this._Lecture = value; }
        }

        [Column(Storage = "_Lab")]
        public int Lab
        {
            get { return this._Lab; }
            set { this._Lab = value; }
        }

        public bool IsLab
        {
            get { return (_Lab != 0) ? true : false; }
        }
        public bool IsLecture
        {
            get { return (_Lecture != 0) ? true : false; }
        }
        public string Title
        {
            get { return this._Teacher.Entity.LastName + ' ' + this._Group.Entity.Title + ' ' + this._Subject.Entity.Title; }
        }
    }
    struct AtomLoad
    {
        public int SubjectID;
        public int GroupID;
        public int TeacherID;
        void AtomLesson()
        {
            TeacherID = 0;
            GroupID = 0;
            SubjectID = 0;
        }
    }
}
