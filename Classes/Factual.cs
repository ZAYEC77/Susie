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

namespace Susie
{
    class Factual
    {
        private Table<AtomFact> fact;
        public BindingSource Bind;
        private Teacher selectedTeacher;
        private Group selectedGroup;
        private DataContext dataContext;

        public Factual(DataContext dataContext)
        {
            this.dataContext = dataContext;
            Bind = new BindingSource();
        }
        public void Load()
        {
            fact = dataContext.GetTable<AtomFact>();
            Refresh();
        }
        private void Refresh()
        {
            List<AtomFact> list = new List<AtomFact>();
            list = fact.ToList<AtomFact>();
            if (selectedGroup != null)
                list = list.Where(l => l.Group == selectedGroup).ToList();
            if (selectedTeacher != null)
                list = list.Where(l => l.Teacher == selectedTeacher).ToList();
            Bind.DataSource = null;
            Bind.DataSource = list;
        }
        public Group SelectedGroup
        { 
            set
            {
                selectedGroup = value;
                Refresh();
            }
        }
        public Teacher SelectedTeacher
        {
            set
            {
                selectedTeacher = value;
                Refresh();
            }
        }
    }

    [Table(Name = "Factual")]
    class AtomFact
    {
        private string _ID = "";
        private int _TeacherID;
        private int _GroupID;
        private int _SubjectID;
        private int _Count;

        private EntityRef<Teacher> _Teacher;
        private EntityRef<Group> _Group;
        private EntityRef<Subject> _Subject;

        public AtomFact()
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
        [Column(Storage = "_Count")]
        public int Count
        {
            get { return this._Count; }
            set { this._Count = value; }
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
    }
}
