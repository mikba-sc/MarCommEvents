using MarCommEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace MarCommEvents.DAL
{
    public static class Event
    {
        public static List<EventModel> Events()
        {
            EventModel m = new EventModel();
            m.Title = "flobbity";

            List<EventModel> l = new List<EventModel>();

            l.Add(m);
            l.Add(m);
            l.Add(m);

            return l;
        }
    }
}