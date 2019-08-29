using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FrontEnd
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleTable.EnableOptimizations = true;

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }

        }
        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Error("Exception: " + exception.Message.ToString());
            Response.Clear();
            HttpException httpException = exception as HttpException;
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["exception"] = exception;
            if (httpException != null)
            {

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        routeData.Values["action"] = "NotFound";
                        break;
                    case 500:
                        // server error
                        routeData.Values["action"] = "Error";
                        break;
                    case 401:
                        // server error
                        routeData.Values["action"] = "UnAuthorize";
                        break;
                }
            }
            // Clear the error on server.
            Server.ClearError();

            // Avoid IIS7 getting in the middle
            Response.TrySkipIisCustomErrors = true;
        }
    }
}
