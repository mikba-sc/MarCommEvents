using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarCommEvents.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MarCommEvents.Models;

namespace MarCommEvents.Controllers.Tests
{
    [TestClass()]
    public class HomeTest
    {
        private void initDB()
        {
            DAL.DB.InitDev();
        }

        [TestMethod()]
        public void IndexTest()
        {
            initDB();

            HomeController controller = new HomeController();
            ViewResult v = controller.Index() as ViewResult;
            List<EventModel> m = v.Model as List<EventModel>;

            Assert.IsNotNull(v);
            Assert.IsNotNull(m);
            Assert.IsTrue(m.Count > 0);


        }
    }
}
