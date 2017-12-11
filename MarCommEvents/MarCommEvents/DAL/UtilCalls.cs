using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MarCommEvents.DAL
{
    public class UtilCalls
    {
        public static void exNonQuery(string connstr, string createSql)
        {
            using (var connection = new SqlConnection(connstr))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = createSql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}