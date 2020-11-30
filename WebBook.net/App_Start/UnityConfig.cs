using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebBook.net.Service;

namespace WebBook.net
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
             container.RegisterType<IBookService, BookService>(TypeLifetime.Scoped);
             //container.RegisterMvcController(Assembly.GetExecutingAssembly());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}