﻿using System;
using System.IO;
using System.Web.Http;

namespace Web_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            Response.Clear();
            Server.ClearError();
        }
    }
}

