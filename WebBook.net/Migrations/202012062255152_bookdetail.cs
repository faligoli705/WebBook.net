namespace WebBook.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookdetail : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookDetailsModels", newName: "BookDetails");
            AlterColumn("dbo.BookDetails", "FileNameDoc", c => c.String());
            AlterColumn("dbo.BookDetails", "FileSubject", c => c.String());
            AlterColumn("dbo.BookDetails", "Publisher", c => c.String());
            AlterColumn("dbo.BookDetails", "Editor", c => c.String());
            AlterColumn("dbo.BookDetails", "Printery", c => c.String());
            AlterColumn("dbo.BookDetails", "Other", c => c.String());
            AlterColumn("dbo.BookDetails", "Author", c => c.String());
            AlterColumn("dbo.BookDetails", "ForeignAuthorName", c => c.String());
            AlterColumn("dbo.BookDetails", "Translator", c => c.String());
            AlterColumn("dbo.BookDetails", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookDetails", "FileName", c => c.String(maxLength: 100));
            AlterColumn("dbo.BookDetails", "Translator", c => c.String(maxLength: 100));
            AlterColumn("dbo.BookDetails", "ForeignAuthorName", c => c.String(maxLength: 100));
            AlterColumn("dbo.BookDetails", "Author", c => c.String(maxLength: 100));
            AlterColumn("dbo.BookDetails", "Other", c => c.String(maxLength: 1500));
            AlterColumn("dbo.BookDetails", "Printery", c => c.String(maxLength: 150));
            AlterColumn("dbo.BookDetails", "Editor", c => c.String(maxLength: 150));
            AlterColumn("dbo.BookDetails", "Publisher", c => c.String(maxLength: 150));
            AlterColumn("dbo.BookDetails", "FileSubject", c => c.String(maxLength: 150));
            AlterColumn("dbo.BookDetails", "FileNameDoc", c => c.String(nullable: false, maxLength: 150));
            RenameTable(name: "dbo.BookDetails", newName: "BookDetailsModels");
        }
    }
}
