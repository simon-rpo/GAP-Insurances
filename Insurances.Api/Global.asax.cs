using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Insurances.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-CO"); //Default Lenguaje
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Just for IE and older Browsers.
            HttpContext.Current.Response.AddHeader("Access-Control-Expose-Headers", "Content-Disposition");
        }
    }
}
