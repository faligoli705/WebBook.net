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
        
        // private readonly IBookService _bookService;
        //public HomeController(IBookService bookService)
        //{
        //    this._bookService = bookService;
        //}
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListBook()
        {
        //     var result = _bookService.ListBook().ToArray();
        //    //if (!result.Any())
        //    //    return HttpNotFound() ;
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