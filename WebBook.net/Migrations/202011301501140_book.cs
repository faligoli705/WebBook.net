namespace WebBook.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDtailsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileNameDoc = c.String(nullable: false, maxLength: 150),
                        FileSubject = c.String(maxLength: 150),
                        Publisher = c.String(maxLength: 150),
                        Editor = c.String(maxLength: 150),
                        Printery = c.String(maxLength: 150),
                        PublicationYear = c.DateTime(nullable: false),
                        BibliographyNumber = c.Int(nullable: false),
                        ISBN = c.Long(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfPages = c.Int(nullable: false),
                        Link = c.String(),
                        Extension = c.String(),
                        FileSize = c.Long(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        Other = c.String(maxLength: 1500),
                        Author = c.String(maxLength: 100),
                        ForeignAuthorName = c.String(maxLength: 100),
                        Translator = c.String(maxLength: 100),
                        FileName = c.String(maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookDtailsModels");
        }
    }
}
