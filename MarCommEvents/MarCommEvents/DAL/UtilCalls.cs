using MarCommEvents.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MarCommEvents.DAL
{
    public class UtilCalls
    {
        public static void exNonQuery(string connstr, string createSql)
        {
            string[] sep = new string[] { "GO" };

            string[] work = createSql.Split(sep, StringSplitOptions.None);

            foreach (string s in work)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    using (var connection = new SqlConnection(connstr))
                    {
                        connection.Open();
                        SqlCommand cmd = connection.CreateCommand();

                        cmd.CommandText = s;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void CallSprocNonQuery(string sprocname, List<SqlParameter> parms)
        {
            //            using (var conn = new SqlConnection("Data Source = PDWWAT01; Initial Catalog = MarCommEvents; User Id = MarCommSystem; Password = testy; ")) // DAL.DB.ConnStr()))
            using (var conn = new SqlConnection(DAL.DB.ConnStr()))
            {
                conn.Open();
                using (var command = new SqlCommand(sprocname, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter p in parms)
                    {
                        command.Parameters.Add(p);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }


        internal static List<T> CallSprocTypedList<T>(string sprocname, List<SqlParameter> parms)
        {
            List<T> ret = new List<T>();
            
            using (var conn = new SqlConnection(DAL.DB.ConnStr()))
            {
                conn.Open();
                using (var command = new SqlCommand(sprocname, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter p in parms)
                    {
                        command.Parameters.Add(p);
                    }

                    SqlDataReader r = command.ExecuteReader();

                    while(r.Read())
                    {
                        List<object> args = new List<object>();
                        args.Add(r);
                        Type[] t = new Type[] { typeof(SqlDataReader) };
                        MethodInfo m = typeof(T).GetMethod("FromSqlRow",BindingFlags.Static | BindingFlags.Public);
                        object o = Activator.CreateInstance(typeof(T), null);
                        object tmp = m.Invoke(o, args.ToArray());
                        ret.Add((T)tmp);
                    }   
                }
            }

            return ret;
        }
    }
}