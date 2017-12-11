using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MarCommEvents.DAL.Init.LDB
{
    public class DB
    {
        private static string _mstconstr = String.Format(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True");
        private const string DB_DIRECTORY = "Data";

        public static string init()
        {
            try
            {
                string dbName = "MarCommEvents";
                string outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DB_DIRECTORY);
                string mdfFilename = dbName + ".mdf";
                string dbFileName = Path.Combine(outputFolder, mdfFilename);
                string logFileName = Path.Combine(outputFolder, String.Format("{0}_log.ldf", dbName));
                // Create Data Directory If It Doesn't Already Exist.
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }


                if (File.Exists(logFileName)) {
                    File.Delete(logFileName);
                }
                if (File.Exists(dbFileName)) {
                    File.Delete(dbFileName);
                }

                CreateDatabase(dbName, dbFileName);

                // connstr for new catalog
                string connectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFileName={1};Initial Catalog={0};Integrated Security=True;", dbName, dbFileName);
                

                return connectionString;
            }
            catch
            {
                throw;
            }
        }

        public static bool CreateDatabase(string dbName, string dbFileName)
        {
            try
            {
                using (var connection = new SqlConnection(_mstconstr))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();


                    DetachDatabase(dbName);

                    cmd.CommandText = String.Format("CREATE DATABASE {0} ON (NAME = N'{0}', FILENAME = '{1}')", dbName, dbFileName);
                    cmd.ExecuteNonQuery();
                }

                if (File.Exists(dbFileName)) return true;
                else return false;
            }
            catch
            {
                throw;
            }

        }

        public static bool DetachDatabase(string dbName)
        {
            try
            {
                using (var connection = new SqlConnection(_mstconstr))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = String.Format("exec sp_detach_db '{0}'", dbName);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        //private static void DropAndCreate(string connstr) {
        //    using (var con = new SqlConnection(connstr))
        //    {
        //        con.Open();
        //        using (var cmd = new SqlCommand("CREATE DATABASE test", con))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}


    }
}