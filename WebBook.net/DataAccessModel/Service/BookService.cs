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

        public bool AddBook(BookDetailModelDto book)
        {
            var isbn = _context.BookDetailsModels.FirstOrDefault(x => x.ISBN == book.ISBN);
            var bibliographyNumber = _context.BookDetailsModels.FirstOrDefault(x => x.BibliographyNumber == book.BibliographyNumber);
            if (isbn != null || bibliographyNumber != null)
            {
                return false;
            }
            else
            {
                var data = _context.BookDetailsModels.Add(new BookDetailsModel()
                {
                    FileNameDoc = book.FileNameDoc,
                    FileSubject = book.FileSubject,
                    Publisher = book.Publisher,
                    Editor = book.Editor,
                    Printery = book.Printery,
                    PublicationYear = DateTime.Now,
                    BibliographyNumber = book.BibliographyNumber,
                    ISBN = book.ISBN,
                    Price = book.Price,
                    NumberOfPages = book.NumberOfPages,
                    Link = book.Link,
                    Extension = "1",
                    FileSize = 12365,
                    UploadDate = DateTime.Now,
                    Other = book.Other,
                    Author = book.Author,
                    ForeignAuthorName = book.ForeignAuthorName,
                    Translator = book.Translator,
                    FileName = "File Name",
                    IsDelete = false
                });
                _context.Entry(data).State = EntityState.Added;
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteBook(BookDetailsModel bookDelete)
        {
            _context.Entry(bookDelete).State = EntityState.Deleted;
           // _context.BookDetailsModels.Remove(bookDelete);
            _context.SaveChanges();

            return true;
        }

        public BookDetailsModel GetBookById(int id)
        {

            return _context.BookDetailsModels.Find(id);
        }

        public IEnumerable<BookDetailsModel> ListBook()
        {

            return _context.BookDetailsModels.Where(book => book.IsDelete == false).ToList();
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
