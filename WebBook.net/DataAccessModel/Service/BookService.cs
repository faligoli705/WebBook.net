using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebBook.net.DataAccessDto;
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

        public BookDetailsModel AddBook(BookDetailsModel book)
        {
            var isbn = _context.BookDetailsModels.FirstOrDefault(x => x.ISBN == book.ISBN);
            var bibliographyNumber = _context.BookDetailsModels.FirstOrDefault(x => x.BibliographyNumber == book.BibliographyNumber);
            if (isbn != null)
            {
                return isbn;
            }
            if (bibliographyNumber != null)
                return bibliographyNumber;
            else
            {
                book.PublicationYear = DateTime.Now;
                book.FileSize = 111;
                book.Extension = "1";
                book.UploadDate = DateTime.Now;
                book.FileName = "ss";
                var data = _context.BookDetailsModels.Add(book);
               //_context.Entry(data).State = EntityState.Added;
                _context.SaveChanges();                
                return data;
            }
        }

        public bool DeleteBook(BookDetailsModel bookDelete)
        {
            _context.Entry(bookDelete).State = EntityState.Deleted;
           // _context.BookDetailsModels.Remove(bookDelete);
            _context.SaveChanges();

            return true;
        }

        public  BookDetailsModel GetBookById(int id)
        {
            
            return _context.BookDetailsModels.Find(id);
        }

        public IEnumerable<BookDetailsModel> ListBook()
        {
            return _context.BookDetailsModels.Where(x => x.IsDelete == false).ToList();
            
                
        }

        public bool UpdateBook(BookDetailModelDto bookUpdate)

        {
            var isbn = _context.BookDetailsModels.FirstOrDefault(x => x.Id != bookUpdate.Id && x.ISBN == bookUpdate.ISBN);
            var bibliographyNumber = _context.BookDetailsModels.FirstOrDefault(x => x.Id != bookUpdate.Id && x.BibliographyNumber == bookUpdate.BibliographyNumber);
            if (isbn != null || bibliographyNumber != null)
            {
                return false;
            }
            else
            {
                var n = _context.BookDetailsModels.SingleOrDefault(x => x.Id == bookUpdate.Id);
                n.FileNameDoc = bookUpdate.FileNameDoc;
                n.FileSubject = bookUpdate.FileSubject;
                n.Publisher = bookUpdate.Publisher;
                n.Editor = bookUpdate.Editor;
                n.Printery = bookUpdate.Printery;
                n.PublicationYear = DateTime.Now;
                n.BibliographyNumber = bookUpdate.BibliographyNumber;
                n.ISBN = bookUpdate.ISBN;
                n.Price = bookUpdate.Price;
                n.NumberOfPages = bookUpdate.NumberOfPages;
                n.Link = bookUpdate.Link;
                n.Extension = "1";
                n.FileSize = 1;
                n.UploadDate = DateTime.Now;
                n.Other = bookUpdate.Other;
                n.Author = bookUpdate.Author;
                n.ForeignAuthorName = bookUpdate.ForeignAuthorName;
                n.Translator = bookUpdate.Translator;
                n.FileName = "File Name";
                n.IsDelete = false;

                // _context.Entry(bookUpdate.Id).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }

    }
}
