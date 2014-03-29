using System;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace Susie
{
    [Table(Name = "Speciality")]
    class Speciality
    {
        private int _ID = 0;
        private string _Title;
        private EntitySet<Group> _Groups;

        public Speciality() 
        { 
            this._Groups = new EntitySet<Group>();
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

        [Association(Storage = "_Groups", OtherKey = "SpecialID")]
        public EntitySet<Group> Groups
        {
            get { return this._Groups; }
            set { this._Groups.Assign(value); }
        }
    }
}
