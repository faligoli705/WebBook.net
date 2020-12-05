using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebBook.net.DataAccessDto;
using WebBook.net.Models;

namespace WebBook.net.Service
{
   public interface IBookService 
    {
        bool AddBook(BookDetailModelDto bookAdd);
        bool UpdateBook(BookDetailModelDto bookUpdate);
        bool DeleteBook(BookDetailsModel bookDelete);
        BookDetailsModel GetBookById(int id);
        IEnumerable<BookDetailsModel> ListBook();


    }
}
