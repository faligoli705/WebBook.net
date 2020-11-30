using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBook.net.Models
{
    public class BookDtailsModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان کتاب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string FileNameDoc { get; set; }

        [Display(Name = "موضوع کتاب")]
        [MaxLength(150, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FileSubject { get; set; }

        [Display(Name = "ناشر")]
        [MaxLength(150, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Publisher { get; set; }

        [Display(Name = "ویراستار")]
        [MaxLength(150, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string Editor { get; set; }

        [Display(Name = "نام نشریه")]
        [MaxLength(150, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Printery { get; set; }

        [Display(Name = " سال نشر")]
         public DateTime PublicationYear { get; set; }

        [Display(Name = " شماره کتاب شناسی ملی")]
        public int BibliographyNumber { get; set; }

        [Display(Name = "شابک")]
        public Int64 ISBN { get; set; }

        [Display(Name = "قیمت ")]
        public decimal Price { get; set; }

        [Display(Name = " تعداد صفحات")]
        public Int32 NumberOfPages { get; set; }

        [Display(Name = " پیوند")]
        public string Link { get; set; }

        public string Extension { get; set; }
        public Int64 FileSize { get; set; }
        public DateTime UploadDate { get; set; }

        [Display(Name = "توضیحات اضافه ")]
        [MaxLength(1500, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string Other { get; set; }

        [Display(Name = "  نام مولف/نویسنده")]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Author { get; set; }
        [Display(Name = "نویسنده خارجی")]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string ForeignAuthorName { get; set; }
        [Display(Name = " مترجم")]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string Translator { get; set; }

        [Display(Name = "نام تصویر")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string FileName { get; set; }
        public bool IsDelete { get; set; }
    }
}