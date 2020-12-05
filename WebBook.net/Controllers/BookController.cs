using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebBook.net.DataAccessDto;
using WebBook.net.Models;
using WebBook.net.Service;

namespace WebBook.net.Controllers
{
    [Route("api/{controllers}")]
    public class BookController : ApiController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public IHttpActionResult ListBook()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var lst = _bookService.ListBook().Select(b => new BookDetailModelDto
            {
                Id = b.Id,
                FileNameDoc = b.FileNameDoc,
                FileSubject = b.FileSubject,
                Publisher = b.Publisher,
                Author = b.Author,
                ForeignAuthorName = b.ForeignAuthorName,
                Translator = b.Translator,
                Editor = b.Editor,
                Price = b.Price
            }).ToList();
            return Ok(lst);
        }

        [Route("api/GetBookFindGetById/{id:int}")]
        public IHttpActionResult GetBookFindGetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var bookId = _bookService.GetBookById(id);
            return Ok(bookId);
        }

        // [Route("api/AddBook")]
        [HttpPost]
        public IHttpActionResult AddBook(BookDetailModelDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = _bookService.AddBook(book).ToString();
            if (data == "False")
            {
                return BadRequest("<script language='javascript' type='text/javascript'>alert('شناسه ملی یا شابک تکراری می باشد ');</script>");
            }
            return Ok(data);
        }

        [Route("api/EditBook/{id:int}")]
        [HttpPut]
        public IHttpActionResult EditBook(BookDetailModelDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = _bookService.UpdateBook(book).ToString();
            if (data == "False")
            {
                return BadRequest("<script language='javascript' type='text/javascript'>alert('شناسه ملی یا شابک تکراری می باشد ');</script>");
            }
            return Ok(data);
        }

        [Route("api/DeleteBook/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBook(BookDetailsModel book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _bookService.DeleteBook(book);
            return Ok();
        }
    }
}
