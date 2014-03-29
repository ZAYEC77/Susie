using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace Susie
{
    [Table(Name = "Teacher")]
    class Teacher
    {
        private int _ID = 0;
        private string _FirstName;
        private string _LastName;
        private string _MiddleName;

        private EntitySet<Load> _Loads;
        private EntitySet<Lesson> _Lessons;

        public Teacher()
        {
            this._Loads = new EntitySet<Load>();
            this._Lessons = new EntitySet<Lesson>();
        }

        [Column(IsPrimaryKey = true, Storage = "_ID")]
        public int ID
        {
            get { return this._ID; }
        }

        [Column(Storage = "_FirstName")]
        public string FirstName
        {
            get { return this._FirstName; }
            set { this._FirstName = value; }
        }

        [Column(Storage = "_LastName")]
        public string LastName
        {
            get { return this._LastName; }
            set { this._LastName = value; }
        }

        [Column(Storage = "_MiddleName")]
        public string MiddleName
        {
            get { return this._MiddleName; }
            set { this._MiddleName = value; }
        }

        [Association(Storage = "_Loads", OtherKey = "TeacherID")]
        public EntitySet<Load> Loads
        {
            get { return this._Loads; }
            set { this._Loads.Assign(value); }
        }

        public EntitySet<Lesson> Lessons
        {
            get { return this._Lessons; }
            set { this._Lessons.Assign(value); }
        }

        public string FullName()
        {
            return this._LastName + ' ' + this._FirstName[0] + ". " + this._MiddleName[0] + "."; 
        }

        public string Title
        {
            get { return this._LastName + ' ' + this._FirstName + ' ' + this._MiddleName; }
        }

        public bool IsMember(List<Teacher> T)
        {
            return (from t in T
                    where this == t
                    select t).Count() > 0;
        }
        public int CountOfHours(Lesson L, Group G)
        {
            int count = 0;
            foreach (Lesson l in this.Lessons.Where(les => les.Semester == L.Semester).Where(les => les.Subject == L.Subject).Where(les => les.Groups.IndexOf(G) > -1).ToList())
            {
                if (l.Type == 0)
                    count += 2;
                else
                    count++;
            }
            return count;
        }
    }
}
