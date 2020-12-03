using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBook.net.Models;

namespace WebBook.net.Service
{
    public class BookService : IBookService
    {
        private readonly BookDetailsContext _context;
        public BookService(BookDetailsContext context)
        {
            this._context = context;
        }

        public int AddBook(BookDetailsModel bookAdd)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(BookDetailsModel bookDelete)
        {
            throw new NotImplementedException();
        }

        public BookDetailsModel GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDetailsModel> ListBook()
        {
            
            return _context.BookDetailsModels.Where(book => book.IsDelete == false).ToList();
        }

        public bool UpdateBook(BookDetailsModel bookUpdate)
        {
            throw new NotImplementedException();
        }
    }
}