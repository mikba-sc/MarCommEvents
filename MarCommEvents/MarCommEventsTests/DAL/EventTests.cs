using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarCommEvents.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarCommEvents.Models;
using MarCommEventsTests;

namespace MarCommEvents.DAL.Tests
{
    [TestClass()]
    public class EventTests
    {
        [TestMethod()]
        public void EventsTest()
        {
            Utils.InitDB();

            List<EventModel> m = DAL.Event.Events();

            Assert.IsNotNull(m);
            Assert.IsTrue(m.Count > 0);

        }
    }
}