using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBook.net.Models;

namespace WebBook.net.Service
{
    public class BookService : IBookService
    {
        private readonly BookDtailsContext _context;
        public BookService(BookDtailsContext context)
        {
            this._context = context;
        }

        public bool AddBook(BookDtailsModel bookAdd)
        {
            var isbn = _context.BookDtailsModels.Where(b => b.ISBN == bookAdd.ISBN);
            var BibliographyNumber=_context.BookDtailsModels.Where(b => b.BibliographyNumber == bookAdd.BibliographyNumber);
            if (isbn == null && BibliographyNumber==null)
            {
                _context.BookDtailsModels.Add(bookAdd);
               _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteBook(BookDtailsModel bookDelete)
        {
            
            _context.BookDtailsModels.Remove(bookDelete);
            _context.SaveChanges();
            return true;
        }

        public BookDtailsModel GetBookById(int id)
        {
            var idBook = _context.BookDtailsModels.FirstOrDefault(b => b.Id == id);
            return idBook;
        }

        public IEnumerable<BookDtailsModel> ListBook()
        {
            return _context.BookDtailsModels.Where(m => m.IsDelete == false).ToList();

        }

        public bool UpdateBook(BookDtailsModel bookUpdate)
        {
            _context.SaveChanges();
            return true;
        }
    }
}