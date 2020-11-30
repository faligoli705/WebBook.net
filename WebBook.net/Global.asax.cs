using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebBook.net.Models;
using WebBook.net.Service;

namespace WebBook.net
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IBookService, BookService>(Lifestyle.Scoped);

            container.Register<BookDtailsContext>(() => { return new BookDtailsContext(); }, Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
          //  IBookService bookService = container.GetInstance<IBookService>();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}