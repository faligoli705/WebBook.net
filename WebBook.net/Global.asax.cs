using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using WebBook.net.Service;

namespace WebBook.net
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityConfig.RegisterComponents();

           /// var container = new Container();
           // container.Register<IBookService, BookService>();
           // container.RegisterMvcController(Assembly.GetExecutingAssembly());
            //DependencyResolver.SetResolver(new SimpleInjectionDependencyResolver(container));
        }
    }
}