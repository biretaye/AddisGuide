namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDestinationFromSP : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceProviderLocation", "DestinationID", "dbo.Destination");
            DropIndex("dbo.ServiceProviderLocation", new[] { "DestinationID" });
            DropColumn("dbo.ServiceProviderLocation", "DestinationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceProviderLocation", "DestinationID", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceProviderLocation", "DestinationID");
            AddForeignKey("dbo.ServiceProviderLocation", "DestinationID", "dbo.Destination", "DestinationID", cascadeDelete: true);
        }
    }
}
