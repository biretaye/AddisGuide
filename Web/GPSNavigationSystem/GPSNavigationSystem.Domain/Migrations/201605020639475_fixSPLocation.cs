namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixSPLocation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceProviderLocation", "ServiceProviderID", "dbo.ServiceProvider");
            DropForeignKey("dbo.ServiceProviderLocation", "DestinationID", "dbo.Destination");
            DropIndex("dbo.ServiceProviderLocation", new[] { "ServiceProviderID" });
            DropIndex("dbo.ServiceProviderLocation", new[] { "DestinationID" });
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderID", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceProviderLocation", "DestinationID", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderLatitude", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderLongitude", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceProviderLocation", "ServiceProviderID");
            CreateIndex("dbo.ServiceProviderLocation", "DestinationID");
            AddForeignKey("dbo.ServiceProviderLocation", "ServiceProviderID", "dbo.ServiceProvider", "ServiceProviderID", cascadeDelete: true);
            AddForeignKey("dbo.ServiceProviderLocation", "DestinationID", "dbo.Destination", "DestinationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceProviderLocation", "DestinationID", "dbo.Destination");
            DropForeignKey("dbo.ServiceProviderLocation", "ServiceProviderID", "dbo.ServiceProvider");
            DropIndex("dbo.ServiceProviderLocation", new[] { "DestinationID" });
            DropIndex("dbo.ServiceProviderLocation", new[] { "ServiceProviderID" });
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderLongitude", c => c.Double());
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderLatitude", c => c.Double());
            AlterColumn("dbo.ServiceProviderLocation", "DestinationID", c => c.Int());
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderID", c => c.Int());
            CreateIndex("dbo.ServiceProviderLocation", "DestinationID");
            CreateIndex("dbo.ServiceProviderLocation", "ServiceProviderID");
            AddForeignKey("dbo.ServiceProviderLocation", "DestinationID", "dbo.Destination", "DestinationID");
            AddForeignKey("dbo.ServiceProviderLocation", "ServiceProviderID", "dbo.ServiceProvider", "ServiceProviderID");
        }
    }
}
