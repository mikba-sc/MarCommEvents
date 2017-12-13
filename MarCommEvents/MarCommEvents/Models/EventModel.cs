using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MarCommEvents.Models
{
    public class EventModel
    {
        public Guid ID;
        public bool Approved;
        public bool NonEvent;
        public string Title;
        public string Location;
        public string Contact;
        public string Description;
        public DateTime Starts;
        public DateTime Ends;
        public bool AllDay;
        public Guid Cause;
        public Guid Type;
        public string ogImage;
        public string ogTitle;
        public string ogType;
        public string LandingpageURL;
        public string BrochureURL;
        public string PresentationURL;
        public string RegOnlineURL;
        public string Cost;

        public static EventModel FromSqlRow(SqlDataReader row)
        {
            EventModel ret = new EventModel();

            ret.AllDay = (bool)row["AllDay"];
            ret.Approved = (bool)row["Approved"];
            ret.NonEvent = (bool)row["NonEvent"];
            
            ret.BrochureURL = (string)row["BrochureURL"];
            ret.Contact = (string)row["Contact"];
            ret.Cost = (string)row["Cost"];
            ret.Description = (string)row["Description"];
            ret.LandingpageURL = (string)row["LandingpageURL"];
            ret.Location = (string)row["Location"];
            ret.ogImage = (string)row["ogImage"];
            ret.ogTitle = (string)row["ogTitle"];
            ret.ogType = (string)row["ogType"];
            ret.PresentationURL = (string)row["PresentationURL"];
            ret.RegOnlineURL = (string)row["RegonlineURL"];
            ret.Title = (string)row["Title"];
            
            ret.Cause = (Guid)row["Cause"];
            ret.ID = (Guid)row["ID"];
            ret.Type = (Guid)row["type"];

            ret.Ends = (DateTime)row["Ends"];
            ret.Starts = (DateTime)row["Starts"];

            return ret;
        }

        public EventModel() { }
    }
}


 
