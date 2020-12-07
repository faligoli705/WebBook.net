using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBook.net.DataAccessDto;
using WebBook.net.Models;

namespace WebBook.net.App_Start
{
    public  class AutomapperConfig : Profile
    {
        public void Init()
        {
            CreateMap<BookDetailsModel, BookDetailDto>();
        }
    }
}