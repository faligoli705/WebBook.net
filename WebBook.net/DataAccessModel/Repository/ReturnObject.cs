using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBook.net.DataAccessModel.Repository
{
    public class ReturnObject
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public dynamic Result { get; set; }
    }
}