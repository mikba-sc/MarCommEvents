﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MarCommEvents
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // setup db
            if (ConfigurationManager.ConnectionStrings.Count > 0 && ConfigurationManager.ConnectionStrings["default"] != null)
            {
                ConnectionStringSettings c = ConfigurationManager.ConnectionStrings["default"];
                DAL.DB.InitProd(c.ConnectionString);
//                DAL.Init.LDB.seed.LoadData();
            }
            else
            {
                DAL.DB.InitDev();
            }
        }
    }
}
