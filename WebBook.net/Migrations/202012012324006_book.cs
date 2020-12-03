namespace WebBook.net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookDetailsModels", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookDetailsModels", "IsDelete");
        }
    }
}
