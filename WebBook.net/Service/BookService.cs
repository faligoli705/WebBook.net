using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebBook.net.DataAccessDto;
using WebBook.net.DataAccessModel.Service;
using WebBook.net.Domain.Entities;
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

        public ServiceResult<BookDetails> AddBook(BookDetails book)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(book.FileNameDoc))
                errors.Add("Name is Null");

            if (_context.BookDetails.Any(a => a.ISBN == book.ISBN))
                errors.Add("Isbn is dupplicate");

            if (_context.BookDetails.Any(a => a.BibliographyNumber == book.BibliographyNumber))
                errors.Add("Bibliography Number is dupplicate");

            if (errors.Any())
                return ServiceResult<BookDetails>.Failed(errors);

            book.UploadDate = DateTime.Now;
            book.PublicationYear = DateTime.Now;
            book.IsDelete = false;
            _context.BookDetails.Add(book);
            var result = _context.SaveChanges();

            if (result > 0)
                return ServiceResult<BookDetails>.Succeed(book);
            return ServiceResult<BookDetails>.Failed(new List<string> { "Data not inserted!!!" });
        }

        public ServiceResult<BookDetails> DeleteBook(int id)
        {
            var errors = new List<string>();
            if (id < 0)
                errors.Add("Nothing found or not selected");

            if (_context.BookDetails.Any(x => x.Id == id && x.IsDelete != false))
                errors.Add("It has already been deleted");

            var book = _context.BookDetails.Find(id);

            if (book == null)
                errors.Add("Nothing found ");
            if (errors.Any())
                return ServiceResult<BookDetails>.Failed(errors);

            var result = _context.SaveChanges();
            if (result > 0)
                book.IsDelete = true;

            if (result > 0)
                return ServiceResult<BookDetails>.Succeed(book);
            return ServiceResult<BookDetails>.Failed(new List<string> { "Data not found or Already deleted" });

        }

        public ServiceResult<BookDetails> GetBookById(int id = 0)
        {
            var errors = new List<string>();
            if (id == 0)
                errors.Add("The id is empty");
      
            var book = _context.BookDetails.Find(id);
             
            if (errors.Any())
                return ServiceResult<BookDetails>.Failed(errors);

             if (book!=null)
                return ServiceResult<BookDetails>.Succeed(book);
            return ServiceResult<BookDetails>.Failed(new List<string> { "Nothing found" });
        }

        public ServiceResult<IEnumerable<BookDetailDto>> ListBook()
        {
            var result = _context.BookDetails.Where(x => !x.IsDelete)
                .Select(x => new BookDetailDto
                {
                    Id = x.Id,
                    FileNameDoc = x.FileNameDoc,
                    FileSubject = x.FileSubject,
                    Publisher = x.Publisher,
                    Editor = x.Editor,
                    ForeignAuthorName = x.ForeignAuthorName,
                    Price = x.Price,
                    Author = x.Author
                });

            return ServiceResult<IEnumerable<BookDetailDto>>.Succeed(result);
        }



        public ServiceResult<BookDetails> UpdateBook(BookDetails book)

        {
            var errors = new List<string>();
            if (_context.BookDetails.Any(x => x.Id != book.Id && x.ISBN == book.ISBN))
                errors.Add("Isbn is duplicate");
            if (_context.BookDetails.Any(x => x.Id != book.Id && x.BibliographyNumber == book.BibliographyNumber))
                errors.Add("Bibliography Number is duplicate");
            if (errors.Any())
                return ServiceResult<BookDetails>.Failed(errors);
            _context.Entry(book).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
                return ServiceResult<BookDetails>.Succeed(book);
            return ServiceResult<BookDetails>.Failed(new List<string> { "Data not inserted" });


        }
    }

}

