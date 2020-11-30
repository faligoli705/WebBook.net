using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBook.net.Models;

namespace WebBook.net.Service
{
    public class BookService : IBookService
    {
        BookDtailsContext context = new BookDtailsContext();
        public int AddBook(BookDtailsModel bookAdd)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(BookDtailsModel bookDelete)
        {
            throw new NotImplementedException();
        }

        public BookDtailsModel FindBookById(int id)
        {
            throw new NotImplementedException();
        }

        public BookDtailsModel GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDtailsModel> ListBook()
        {
           return context.BookDtailsModels.ToList();
        }

        public bool UpdateBook(BookDtailsModel bookUpdate)
        {
            throw new NotImplementedException();
        }
    }
}