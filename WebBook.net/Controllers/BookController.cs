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
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            this._bookService = bookService;
            this._mapper = mapper;
        }

        [HttpGet]
        // public IEnumerable<BookDtailsModel> ListBook() => this._bookService.ListBook().ToList();

        public IHttpActionResult ListBook()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var lst = _mapper.Map<BookDetailModelDto>(_bookService.ListBook());

            // var bookList = _bookService.ListBook();
            return Ok();
            // return res; ;
        }

        [Route("api/GetBookFindGetById/{id:int}")]
        public IHttpActionResult GetBookFindGetById(int id)
        {
            if (ModelState.IsValid)
                return BadRequest();
            var bookId = _bookService.GetBookById(id);
            return Ok(bookId);

        }
        //[HttpPost]
        //public async Task<bool> AddBook(BookDetailsModel book)
        //{
        //    book.FileSize = 122;
        //    book.Extension = "1";
        //    book.FileName = "95";
        //    book.UploadDate = DateTime.Now;
        //    book.PublicationYear = DateTime.Now;
        //    if (!ModelState.IsValid)
        //    {
        //        _context.BookDtailsModels.Add(book);
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;

        //}

        [HttpPut]
        public IHttpActionResult EditBook(BookDetailsModel book)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var bookId = _bookService.UpdateBook(book);

            return Ok(bookId);
        }
        //[Route("api/DeleteBook/{id:int}")]
        //[HttpDelete]
        //public async Task<bool> DeleteBook(int Id, BookDtailsModel book)
        //{

        //    if (Id == book.Id)
        //    {
        //        _context.Entry(Id).State = EntityState.Deleted;
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}
    }
}
