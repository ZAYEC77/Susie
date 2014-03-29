using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;


namespace Susie
{
    [Table(Name = "Subject")]
    class Subject
    {
        private int _ID = 0;
        private string _Title;
        private EntitySet<Load> _Loads;

        public Subject() 
        {
            this._Loads = new EntitySet<Load>();
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

        [Association(Storage = "_Loads", OtherKey = "GroupID")]
        public EntitySet<Load> Loads
        {
            get { return this._Loads; }
            set { this._Loads.Assign(value); }
        }
    }
}
