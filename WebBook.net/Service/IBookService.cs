using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebBook.net.DataAccessDto;
using WebBook.net.DataAccessModel.Service;
using WebBook.net.Domain.Entities;
using WebBook.net.Models;

namespace WebBook.net.Service
{
    public interface IBookService
    {
        ServiceResult<BookDetails> AddBook(BookDetails book);
        ServiceResult<BookDetails> UpdateBook(BookDetails book);
        ServiceResult<BookDetails> DeleteBook(int id);
        ServiceResult<BookDetails> GetBookById(int id);
        ServiceResult<IEnumerable<BookDetailDto>> ListBook();



    }
}
