namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoriesUpdatedBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            AddColumn("dbo.Books", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "CategoryID");
            AddForeignKey("dbo.Books", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            DropColumn("dbo.Books", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Books", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropColumn("dbo.Books", "CategoryID");
            DropTable("dbo.Categories");
        }
    }
}
