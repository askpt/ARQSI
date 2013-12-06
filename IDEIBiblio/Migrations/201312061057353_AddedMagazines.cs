namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMagazines : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        MagazineID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        EditorID = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Title = c.String(),
                        Publish = c.DateTime(nullable: false),
                        Issue = c.String(),
                        Number = c.String(),
                        PeriodicityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MagazineID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Editors", t => t.EditorID, cascadeDelete: true)
                .ForeignKey("dbo.Periodicities", t => t.PeriodicityID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.CategoryID)
                .Index(t => t.EditorID)
                .Index(t => t.PeriodicityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Magazines", "PeriodicityID", "dbo.Periodicities");
            DropForeignKey("dbo.Magazines", "EditorID", "dbo.Editors");
            DropForeignKey("dbo.Magazines", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Magazines", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Magazines", new[] { "PeriodicityID" });
            DropIndex("dbo.Magazines", new[] { "EditorID" });
            DropIndex("dbo.Magazines", new[] { "CategoryID" });
            DropIndex("dbo.Magazines", new[] { "AuthorID" });
            DropTable("dbo.Magazines");
        }
    }
}
