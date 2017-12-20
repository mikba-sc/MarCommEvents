using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarCommEvents.DAL
{
    public class DB
    {
        private static string _connstr = null;

        public static string ConnStr()
        {
            if (string.IsNullOrEmpty(_connstr))
            {
                throw new Exception("DB not initialized");
            }

            return _connstr;
        }

        public static void InitDev()
        {
            if (string.IsNullOrEmpty(_connstr))
            {
                _connstr = Init.LocalDB.Hydrate();
                Init.LDB.seed.LoadData();
            }
        }

        public static void InitProd(string connstr)
        {
            _connstr = connstr;
        }
    }
}