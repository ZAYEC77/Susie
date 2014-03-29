using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Common;
using System.Text;
using System.Data.OleDb;
using System.Data.Linq.Mapping;

namespace Susie
{
    class Connection
    {
        private DataContext dataContext;
        public Connection(System.Data.IDbConnection connection)
        {
            dataContext = new DataContext(connection);
        }
        public DataContext DataContext
        {
            get { return dataContext; }
        }
    }
}
