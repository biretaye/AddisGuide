namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CatagoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ServiceProvider",
                c => new
                    {
                        ServiceProviderID = c.Int(nullable: false, identity: true),
                        ServiceProviderName = c.String(nullable: false),
                        Rating = c.Int(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceProviderID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ServiceProviderLocation",
                c => new
                    {
                        ServiceProviderLocationID = c.Int(nullable: false, identity: true),
                        ServiceProviderID = c.Int(),
                        DestinationID = c.Int(),
                        ServiceProviderLatitude = c.Double(),
                        ServiceProviderLongitude = c.Double(),
                    })
                .PrimaryKey(t => t.ServiceProviderLocationID)
                .ForeignKey("dbo.Destination", t => t.DestinationID)
                .ForeignKey("dbo.ServiceProvider", t => t.ServiceProviderID)
                .Index(t => t.ServiceProviderID)
                .Index(t => t.DestinationID);
            
            CreateTable(
                "dbo.Destination",
                c => new
                    {
                        DestinationID = c.Int(nullable: false, identity: true),
                        DestinationName = c.String(nullable: false),
                        DestinationLatitude = c.Double(),
                        DestinationLongitude = c.Double(),
                    })
                .PrimaryKey(t => t.DestinationID);
            
            CreateTable(
                "dbo.House",
                c => new
                    {
                        HouseID = c.Int(nullable: false, identity: true),
                        HouseNumber = c.String(nullable: false),
                        DestinationID = c.Int(),
                        StreetID = c.Int(),
                        House_Latitude = c.Double(),
                        House_Longitude = c.Double(),
                    })
                .PrimaryKey(t => t.HouseID)
                .ForeignKey("dbo.Destination", t => t.DestinationID)
                .ForeignKey("dbo.Street", t => t.StreetID)
                .Index(t => t.DestinationID)
                .Index(t => t.StreetID);
            
            CreateTable(
                "dbo.Street",
                c => new
                    {
                        StreetID = c.Int(nullable: false, identity: true),
                        StreetName = c.String(nullable: false),
                        StreetStartLatitude = c.Double(),
                        StreetStartLongitude = c.Double(),
                        StreetEndLatitude = c.Double(),
                        StreetEndLongitude = c.Double(),
                    })
                .PrimaryKey(t => t.StreetID);
            
            CreateTable(
                "dbo.StationDestination",
                c => new
                    {
                        StationDestinationID = c.Int(nullable: false, identity: true),
                        StationID = c.Int(nullable: false),
                        DestinationID = c.Int(nullable: false),
                        StationLocation_StationLocationID = c.Int(),
                    })
                .PrimaryKey(t => t.StationDestinationID)
                .ForeignKey("dbo.Destination", t => t.DestinationID, cascadeDelete: true)
                .ForeignKey("dbo.StationLocation", t => t.StationLocation_StationLocationID)
                .Index(t => t.DestinationID)
                .Index(t => t.StationLocation_StationLocationID);
            
            CreateTable(
                "dbo.StationLocation",
                c => new
                    {
                        StationLocationID = c.Int(nullable: false, identity: true),
                        StationType = c.String(nullable: false),
                        StationName = c.String(nullable: false),
                        StationLatitude = c.Double(),
                        StationLongitude = c.Double(),
                    })
                .PrimaryKey(t => t.StationLocationID);
            
            CreateTable(
                "dbo.TrafficSignLocation",
                c => new
                    {
                        TrafficSignLocationID = c.Int(nullable: false, identity: true),
                        TrafficSignID = c.Int(nullable: false),
                        TSLocationStartLatitude = c.Double(),
                        TSLocationStartLongitude = c.Double(),
                        TSLocationEndLatitude = c.Double(),
                        TSLocationEndLongitude = c.Double(),
                    })
                .PrimaryKey(t => t.TrafficSignLocationID)
                .ForeignKey("dbo.TrafficSign", t => t.TrafficSignID, cascadeDelete: true)
                .Index(t => t.TrafficSignID);
            
            CreateTable(
                "dbo.TrafficSign",
                c => new
                    {
                        TrafficSignID = c.Int(nullable: false, identity: true),
                        TrafficSignName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TrafficSignID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        fname = c.String(nullable: false),
                        lanme = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrafficSignLocation", "TrafficSignID", "dbo.TrafficSign");
            DropForeignKey("dbo.ServiceProviderLocation", "ServiceProviderID", "dbo.ServiceProvider");
            DropForeignKey("dbo.StationDestination", "StationLocation_StationLocationID", "dbo.StationLocation");
            DropForeignKey("dbo.StationDestination", "DestinationID", "dbo.Destination");
            DropForeignKey("dbo.ServiceProviderLocation", "DestinationID", "dbo.Destination");
            DropForeignKey("dbo.House", "StreetID", "dbo.Street");
            DropForeignKey("dbo.House", "DestinationID", "dbo.Destination");
            DropForeignKey("dbo.ServiceProvider", "CategoryID", "dbo.Category");
            DropIndex("dbo.TrafficSignLocation", new[] { "TrafficSignID" });
            DropIndex("dbo.StationDestination", new[] { "StationLocation_StationLocationID" });
            DropIndex("dbo.StationDestination", new[] { "DestinationID" });
            DropIndex("dbo.House", new[] { "StreetID" });
            DropIndex("dbo.House", new[] { "DestinationID" });
            DropIndex("dbo.ServiceProviderLocation", new[] { "DestinationID" });
            DropIndex("dbo.ServiceProviderLocation", new[] { "ServiceProviderID" });
            DropIndex("dbo.ServiceProvider", new[] { "CategoryID" });
            DropTable("dbo.User");
            DropTable("dbo.TrafficSign");
            DropTable("dbo.TrafficSignLocation");
            DropTable("dbo.StationLocation");
            DropTable("dbo.StationDestination");
            DropTable("dbo.Street");
            DropTable("dbo.House");
            DropTable("dbo.Destination");
            DropTable("dbo.ServiceProviderLocation");
            DropTable("dbo.ServiceProvider");
            DropTable("dbo.Category");
        }
    }
}
