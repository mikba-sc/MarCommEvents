using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarCommEventsTests
{
    class Utils
    {
        public static void InitDB()
        {
            MarCommEvents.DAL.DB.InitDev();
        }
    }
}
