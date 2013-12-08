namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Orders", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Country", c => c.String());
            AlterColumn("dbo.Orders", "PostalCode", c => c.String());
            AlterColumn("dbo.Orders", "City", c => c.String());
            AlterColumn("dbo.Orders", "Address", c => c.String());
            AlterColumn("dbo.Orders", "LastName", c => c.String());
            AlterColumn("dbo.Orders", "FirstName", c => c.String());
        }
    }
}
