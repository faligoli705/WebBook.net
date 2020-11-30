[assembly: WebActivator.PostApplicationStartMethod(typeof(WebBook.net.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace WebBook.net.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Diagnostics;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using WebBook.net.Controllers;
    using WebBook.net.Models;
    using WebBook.net.Service;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //var registration = container.GetRegistration(typeof(BookController)).Registration;

            container.Register<IBookService, BookService>();
            container.Register<BookDtailsContext>();
            Registration registration = container.GetRegistration(typeof(BookDtailsContext)).Registration;
            registration.SuppressDiagnosticWarning(
                         DiagnosticType.DisposableTransientComponent,
                         "Reason of suppression");

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}