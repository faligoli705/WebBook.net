using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBook.net.Domain.Entities
{
    public class BookDetails
    {
        public int Id { get; set; }       
        public string FileNameDoc { get; set; }
        public string FileSubject { get; set; }
        public string Editor { get; set; }
        public string Printery { get; set; }
        public string Publisher { get; set; }

        public DateTime PublicationYear { get; set; }
        public int BibliographyNumber { get; set; }
        public Int64 ISBN { get; set; }
        public decimal Price { get; set; }
        public Int32 NumberOfPages { get; set; }
        public string Link { get; set; }
        public string Extension { get; set; }
        public Int64 FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public string Other { get; set; }
        public string Author { get; set; }
        public string ForeignAuthorName { get; set; }
        public string Translator { get; set; }
        public string FileName { get; set; }
        public bool IsDelete { get; set; }
    }
}