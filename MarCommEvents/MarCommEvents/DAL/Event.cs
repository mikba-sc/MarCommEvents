using MarCommEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace MarCommEvents.DAL
{
    public static class Event
    {
        public static List<EventModel> Events()
        {

            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("From", DateTime.Now.AddDays(-1)));
            parms.Add(new SqlParameter("To", DateTime.Now.AddDays(30)));

            return UtilCalls.CallSprocTypedList<EventModel>("spListEvents", parms);

        }

        public static void PutEvent(EventModel e)
        {
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("ID", e.ID));
            parms.Add(new SqlParameter("Approved", e.Approved));
            parms.Add(new SqlParameter("NonEvent", e.NonEvent));
            parms.Add(new SqlParameter("Title", e.Title));
            parms.Add(new SqlParameter("Location", e.Location));
            parms.Add(new SqlParameter("Contact", e.Contact));
            parms.Add(new SqlParameter("Description", e.Description));
            parms.Add(new SqlParameter("Starts", e.Starts));
            parms.Add(new SqlParameter("Ends", e.Ends));
            parms.Add(new SqlParameter("AllDay", e.AllDay));
            parms.Add(new SqlParameter("Cause", e.Cause));
            parms.Add(new SqlParameter("Type", e.Type));
            parms.Add(new SqlParameter("ogImage", e.ogImage));
            parms.Add(new SqlParameter("ogTitle", e.ogTitle));
            parms.Add(new SqlParameter("ogType", e.ogType));
            parms.Add(new SqlParameter("LandingpageURL", e.LandingpageURL));
            parms.Add(new SqlParameter("BrochureURL", e.BrochureURL));
            parms.Add(new SqlParameter("PresentationURL", e.PresentationURL));
            parms.Add(new SqlParameter("RegonlineURL", e.RegOnlineURL));
            parms.Add(new SqlParameter("Cost", e.Cost));

            UtilCalls.CallSprocNonQuery("spUpsertEvent", parms);
        }

      
    }
}