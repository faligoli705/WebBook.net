using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace WebBook.net.DataAccessModel.Repository
{
    public class ResultService<T>
    {

        public ReturnObjectT<T> GetGoodResult(T result)
        {
            return  new ReturnObjectT<T> { Success = true, Result = result };
        }


        public ReturnObjectT<T> GetGoodResult(T result, IEnumerable<string> errors)
        {
            return new ReturnObjectT<T> { Success = false, Errors = errors, Result = result };
        }
    }
}