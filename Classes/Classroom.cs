using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace Susie
{
    [Table(Name = "Classroom")]
    class Classroom
    {
        private int _ID = 0;
        private string _Title;
        private int _Type;
        private int _Corps;
        private EntitySet<Lesson> _Lessons;

        public Classroom() 
        {
            this._Lessons = new EntitySet<Lesson>();
        }
        [Column(IsPrimaryKey = true, Storage = "_ID")]
        public int ID
        {
            get { return this._ID; }
        }
        [Column(Storage = "_Title")]
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }
        [Column(Storage = "_Type")]
        public int Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }
        [Column(Storage = "_Corps")]
        public int Corps
        {
            get { return this._Corps; }
            set { this._Corps = value; }
        }
        public bool IsLectures
        {
            get { return (_Type == 1) ? false : true; }
        }
        public EntitySet<Lesson> Lessons
        {
            get { return this._Lessons; }
            set { this._Lessons.Assign(value); }
        }

    }
 
}
