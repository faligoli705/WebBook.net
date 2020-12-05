 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebBook.net.Models;
using WebBook.net.Service;

namespace WebBook.net.Controllers
{
    public class HomeController : Controller
    {                       
        public ActionResult Index()                
        
        {
            return View();
        }

        public ActionResult ListBook()
        {
            return PartialView();
        }
       
        public ActionResult AddBook()
        {
            return PartialView();
        }

        public ActionResult EditBook()
        {
            return PartialView();
        }

        public ActionResult DeleteBook()
        {
            return PartialView();
        }

        public ActionResult Specifications()
        {
            return PartialView();
        }

    }
}