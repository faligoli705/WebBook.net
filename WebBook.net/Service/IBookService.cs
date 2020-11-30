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
        int AddBook(BookDtailsModel bookAdd);
        bool UpdateBook(BookDtailsModel bookUpdate);
        bool DeleteBook(BookDtailsModel bookDelete);
        BookDtailsModel FindBookById(int id);
        BookDtailsModel GetBookById(int id);
        IEnumerable<BookDtailsModel> ListBook();


    }
}
