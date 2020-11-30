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
        bool AddBook(BookDtailsModel bookAdd);
        bool UpdateBook(BookDtailsModel bookUpdate);
        bool DeleteBook(BookDtailsModel bookDelete);
        BookDtailsModel GetBookById(int id);
        IEnumerable<BookDtailsModel> ListBook();


    }
}
