namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBooksWithSingleAuthor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Book_BookID", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "Book_BookID" });
            AddColumn("dbo.Books", "AuthorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "AuthorID");
            AddForeignKey("dbo.Books", "AuthorID", "dbo.Authors", "AuthorID", cascadeDelete: true);
            DropColumn("dbo.Authors", "Book_BookID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Book_BookID", c => c.Int());
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropColumn("dbo.Books", "AuthorID");
            CreateIndex("dbo.Authors", "Book_BookID");
            AddForeignKey("dbo.Authors", "Book_BookID", "dbo.Books", "BookID");
        }
    }
}
