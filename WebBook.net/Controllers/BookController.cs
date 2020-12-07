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
using WebBook.net.Service;
using WebBook.net.Models;
using WebBook.net.Service;
using WebBook.net.Domain.Entities;

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
            var result = _bookService.ListBook();
            if (result.IsSucceed)
            {
                if (result.Data != null && result.Data.Any())
                    return Ok(result.Data);
                return NotFound();
            }
            return BadRequest(string.Join(",", result.Errors));
        }
        [Route("api/AddBook")]
        [HttpPost]
        public IHttpActionResult AddBook(BookDetailsModel bookDetailModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _bookService.AddBook(new BookDetails
            {
                FileNameDoc = bookDetailModel.FileNameDoc,
                FileSubject=bookDetailModel.FileSubject,
                Publisher=bookDetailModel.Publisher,
                Editor=bookDetailModel.Editor,
                Printery=bookDetailModel.Printery,
                BibliographyNumber=bookDetailModel.BibliographyNumber,
                ISBN=bookDetailModel.ISBN,
                Price=bookDetailModel.Price,
                NumberOfPages=bookDetailModel.NumberOfPages,
                Link=bookDetailModel.Link,
                Other=bookDetailModel.Other,
                Author=bookDetailModel.Author,
                ForeignAuthorName=bookDetailModel.ForeignAuthorName,
                Translator=bookDetailModel.Translator,
                FileName=bookDetailModel.FileName
            });

            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));
        }

        [Route("api/GetBookFindGetById/{id:int}")]
        public IHttpActionResult GetBookFindGetById(int id)
        {
            var result = _bookService.GetBookById(id);
            if (result.IsSucceed)
            {
                if (result.Data != null)
                    return Ok(result.Data);
                return NotFound();
            }
            return BadRequest(string.Join(",", result.Errors));

        }



        [Route("api/EditBook/{id:int}")]
        [HttpPut]
        public IHttpActionResult EditBook(BookDetails  book)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                return BadRequest(string.Join(",", errors));
            }
            var result = _bookService.UpdateBook(book);
            if (result.IsSucceed)
                return Ok(result.Data);
            return BadRequest(string.Join(",", result.Errors));

        }

        [Route("api/DeleteBook/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var result = _bookService.DeleteBook(id);
            if (result.IsSucceed)
            {
                if (result.Data != null)
                    return Ok(result.Data);
                return NotFound();
            }
            return BadRequest(string.Join(",", result.Errors));           
        }
    }
}
