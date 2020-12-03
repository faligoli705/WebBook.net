using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBook.net.Models;

namespace WebBook.net.Service
{
   public interface IBookService
    {
        int AddBook(BookDetailsModel bookAdd);
        bool UpdateBook(BookDetailsModel bookUpdate);
        bool DeleteBook(BookDetailsModel bookDelete);
         BookDetailsModel GetBookById(int id);
        IEnumerable<BookDetailsModel> ListBook();


    }
}
