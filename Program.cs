using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Susie
{

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
        static private OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\college.mdb");

        static public Connection connection = new Connection(con);

        static public Table<Group> Groups;
        static public Table<Teacher> Teachers;
        static public Table<Speciality> Specialitys;
        static public Table<Classroom> Classrooms;
        static public Table<Subject> Subjects;
        static public Factual fact = new Factual(connection.DataContext);

        static public Schedule schedule = new Schedule(connection.DataContext);

        static public Replacement replacement = new Replacement(connection.DataContext);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }
    }
}
