using MarCommEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarCommEvents.DAL.Init.LDB
{
    public class seed
    {
        public static void LoadData()
        {
        EventModel e = new EventModel();
            e.ID = Guid.NewGuid();
            e.Approved = true;
            e.NonEvent = true;
            e.Title = "title test";
            e.Location = "here";
            e.Description = "testy test";
            e.Starts = DateTime.Now.AddDays(15);
            e.Ends = DateTime.Now.AddDays(15);
            e.AllDay = false;
            e.Contact = "me";
            e.BrochureURL = string.Empty;
            e.Cause = Guid.Empty;
            e.Cost = string.Empty;
            e.LandingpageURL = string.Empty;
            e.ogImage = string.Empty;
            e.ogTitle = string.Empty;
            e.ogType = string.Empty;
            e.PresentationURL = string.Empty;
            e.RegOnlineURL = string.Empty;
            e.Type = Guid.Empty;


            DAL.Event.PutEvent(e);
        }
    }
}