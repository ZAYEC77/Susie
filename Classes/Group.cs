using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace Susie
{
    [Table(Name = "Groupss")]
    class Group
    {
        private int _ID = 0;
        private string _Title;
        private int _SpecialID;
        private int _Course = 0;

        private EntitySet<Load> _Loads;
        private EntityRef<Speciality> _Speciality;
        private EntitySet<Lesson> _Lessons;

        public Group() 
        {
            this._Speciality = new EntityRef<Speciality>();
            this._Loads = new EntitySet<Load>();
            this._Lessons = new EntitySet<Lesson>();
        }

        [Column(IsPrimaryKey = true, Storage = "_ID")]
        public int ID
        {
            get{ return this._ID; }
        }

        [Column(Storage = "_Title")]
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }

        [Column(Storage = "_SpecialID")]
        public int SpecialID
        {
            get { return this._SpecialID; }
            set { this._SpecialID = value; }
        }

        [Column(Storage = "_Course")]
        public int Course
        {
            get { return this._Course; }
            set { this._Course = value; }
        }

        [Association(Storage = "_Speciality", ThisKey = "SpecialID")]
        public Speciality Speciality
        {
            get { return this._Speciality.Entity; }
            set { this._Speciality.Entity = value; }
        }

        [Association(Storage = "_Loads", OtherKey = "GroupID")]
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

        public bool IsMember(List<Group> G)
        {
            return (from g in G
                    where this == g
                    select g).Count() > 0;
        }
    }

    

}
