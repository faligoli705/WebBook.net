using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebBook.net.Models;
using WebBook.net.Service;

namespace WebBook.net.App_Start
{
    public class StartIocReg
    {
        public void StartIocRegister()
        {

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<IBookService, BookService>(Lifestyle.Scoped);
            container.Register<BookDetailsContext>(() =>
            {
                return new BookDetailsContext();
            }, Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Options.EnableAutoVerification = false;
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Register<AutomapperConfig>();
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                   new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}