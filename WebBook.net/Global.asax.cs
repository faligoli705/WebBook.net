using AutoMapper;
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
using WebBook.net.App_Start;
using WebBook.net.Controllers;
using WebBook.net.DataAccessDto;
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

            StartIocReg startIocReg = new StartIocReg();
            startIocReg.StartIocRegister();
 


        }
    }
}