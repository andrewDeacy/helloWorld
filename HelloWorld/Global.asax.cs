using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.IO;
using HelloWorld.Models;

namespace HelloWorld
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            
            // meeting business req...
            StringWriter sw = new StringWriter();
            HelloWorldParameters parameters = new HelloWorldParameters();

            Core.HelloWorld logic = new Core.HelloWorld(sw, parameters);
            logic.PrintHelloWorld();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}