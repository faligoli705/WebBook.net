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
        BookDtailsContext _context = new BookDtailsContext();
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }
        //[HttpGet]
        //public IEnumerable<BookDtailsModel> ListBook()
        //{
          //var result=  _bookService.ListBook().ToList();
          //  if (!result.Any())
          //      return NotFound(

            
          //  return await _context.BookDtailsModels.ToListAsync();
      //  }

        [Route("api/GetBookFindGetById/{id:int}")]
        public async Task<BookDtailsModel> GetBookFindGetById(int id)
        {

            return await _context.BookDtailsModels.FirstOrDefaultAsync(b => b.Id == id);
        }
        [HttpPost]
        public async Task<bool> AddBook(BookDtailsModel book)
        {
            book.FileSize = 122;
            book.Extension = "1";
            book.FileName = "95";
            book.UploadDate = DateTime.Now;
            book.PublicationYear = DateTime.Now;
            if (!ModelState.IsValid)
            {
                _context.BookDtailsModels.Add(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        [HttpPut]
        public async Task<bool> EditBook(int id, BookDtailsModel book)
        {
            Console.Write(id);

            if (id == book.Id)
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        [Route("api/DeleteBook/{id:int}")]
        [HttpDelete]
        public async Task<bool> DeleteBook(int Id, BookDtailsModel book)
        {

            if (Id == book.Id)
            {
                _context.Entry(Id).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
