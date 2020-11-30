using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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
        public IEnumerable<BookDtailsModel> ListBook() => this._bookService.ListBook().ToList();


        [Route("api/GetBookFindGetById/{id:int}")]
        public IHttpActionResult GetBookFindGetById(int id)
        {
            if (ModelState.IsValid)
            {
                var res = _bookService.GetBookById(id);
                return Ok(res);
            }

            return NotFound();
        }
        [HttpPost]
        public IHttpActionResult AddBook(BookDtailsModel book)
        {

            book.UploadDate = DateTime.Now;
            book.PublicationYear = DateTime.Now;
            book.FileSize = 1;
            book.IsDelete = false;
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                var bookdetail = _bookService.AddBook(book);

                return Ok(bookdetail);
            }


        }

        [Route("api/EditBook/{id:int}")]
        [HttpPut]
        public IHttpActionResult EditBook(int id, BookDtailsModel book)
        {

            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);

                return Ok();
            }
            return NotFound();
        }
        [Route("api/DeleteBook/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteBook(int Id, BookDtailsModel book)
        {

            if (Id == book.Id)
            {
                var delete = _bookService.DeleteBook(book);
                return Ok();
            }

            return NotFound();

        }
    }
}
