namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEditors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Editors",
                c => new
                    {
                        EditorID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EditorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Editors");
        }
    }
}
