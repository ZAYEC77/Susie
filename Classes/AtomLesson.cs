using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace Susie
{
    [Table(Name = "Schedule")]
    class AtomLesson
    {
        static private int currentID;
        static public void ResetID()
        {
            currentID = 0;
        }

        private int _ID;
        private int _SubjectID;
        private int _TeacherID;
        private int _GroupID;
        private int _ClassroomID;
        private int _Number;
        private int _Day;
        private int _Type;
        private int _Semester;

        public AtomLesson()
        {
            _ID = currentID++;
        }
        [Column(IsPrimaryKey = true, Storage = "_ID")]
        public int ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }

        [Column(Storage = "_SubjectID")]
        public int SubjectID
        {
            get { return this._SubjectID; }
            set { this._SubjectID = value; }
        }
        [Column(Storage = "_TeacherID")]
        public int TeacherID
        {
            get { return this._TeacherID; }
            set { this._TeacherID = value; }
        }
        [Column(Storage = "_GroupID")]
        public int GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }
        [Column(Storage = "_ClassroomID")]
        public int ClassroomID
        {
            get { return this._ClassroomID; }
            set { this._ClassroomID = value; }
        }
        [Column(Storage = "_Number")]
        public int Number
        {
            get { return this._Number; }
            set { this._Number = value; }
        }
        [Column(Storage = "_Day")]
        public int Day
        {
            get { return this._Day; }
            set { this._Day = value; }
        }
        [Column(Storage = "_Type")]
        public int Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }
        [Column(Storage = "_Semester")]
        public int Semester
        {
            get { return this._Semester; }
            set { this._Semester = value; }
        }
        public string Title
        {
            get { return _SubjectID.ToString() + ' ' + _GroupID.ToString() + ' ' + _TeacherID.ToString(); }
        }
        public string GetQuery(string tableName)
        {
            return "INSERT INTO " + tableName +
                " (ID, GroupID, ClassroomID, SubjectID, TeacherID, [Number], [Day], Type, Semester ) " +
                "VALUES ("
                + _ID + ','
                + _GroupID + ','
                + _ClassroomID + ','
                + _SubjectID + ','
                + _TeacherID + ','
                + _Number + ','
                + _Day + ','
                + _Type + ','
                + _Semester
                + ')';
        }
    }
}
