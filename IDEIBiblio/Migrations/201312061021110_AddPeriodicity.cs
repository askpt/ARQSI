namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPeriodicity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodicities",
                c => new
                    {
                        PeriodicityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberofDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PeriodicityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Periodicities");
        }
    }
}
