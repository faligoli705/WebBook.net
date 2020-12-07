using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace WebBook.net.DataAccessModel.Service
{
    public class ServiceResult<T>
    {

        public bool IsSucceed { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public T Data { get; set; }

        public static ServiceResult<T> Failed(IEnumerable<string> errors)
        {
            return new ServiceResult<T>
            {
                IsSucceed = false,
                Errors = errors
            };
        }

        public static ServiceResult<T> Succeed(T data)
        {
            return new ServiceResult<T>
            {
                IsSucceed = true,
                Data = data
            };
        }

    }
}
