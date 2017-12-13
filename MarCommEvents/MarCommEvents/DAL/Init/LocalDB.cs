using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MarCommEvents.DAL.Init
{
    public class LocalDB
    {
        public static string Hydrate()
        {
            string connstr = createDB();


            return connstr;
        }

        private static string createDB()
        {
            string connstr = LDB.DB.init(); // @"Integrated Security=SSPI;Data Source=(LocalDb)\MSSQLLocalDB;";
            LDB.Tables.Init(connstr);
            LDB.Sprocs.Init(connstr);
//            LDB.seed.LoadData(connstr);
            return connstr;
        }
    }
}