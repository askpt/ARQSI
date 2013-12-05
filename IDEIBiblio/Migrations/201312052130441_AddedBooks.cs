namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        EditorID = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        ISBN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Editors", t => t.EditorID, cascadeDelete: true)
                .Index(t => t.EditorID);
            
            AddColumn("dbo.Authors", "Book_BookID", c => c.Int());
            CreateIndex("dbo.Authors", "Book_BookID");
            AddForeignKey("dbo.Authors", "Book_BookID", "dbo.Books", "BookID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "EditorID", "dbo.Editors");
            DropForeignKey("dbo.Authors", "Book_BookID", "dbo.Books");
            DropIndex("dbo.Books", new[] { "EditorID" });
            DropIndex("dbo.Authors", new[] { "Book_BookID" });
            DropColumn("dbo.Authors", "Book_BookID");
            DropTable("dbo.Books");
        }
    }
}
