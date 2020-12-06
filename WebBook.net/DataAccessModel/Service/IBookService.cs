using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebBook.net.DataAccessDto;
using WebBook.net.DataAccessModel.Repository;
using WebBook.net.Models;

namespace WebBook.net.Service
{
   public interface IBookService 
    {
        BookDetailsModel AddBook(BookDetailsModel bookAdd);
        bool UpdateBook(BookDetailModelDto bookUpdate);
        bool DeleteBook(BookDetailsModel bookDelete);
        BookDetailsModel GetBookById(int id);
        // IEnumerable<BookDetailsModel> ListBook();
        ReturnObjectT<BookDetailsModel> ListBook();


    }
}
