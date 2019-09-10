namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class destinationLongLat1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destination", "DestinationLatitude", c => c.Double());
            AddColumn("dbo.Destination", "DestinationLongitude", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destination", "DestinationLongitude");
            DropColumn("dbo.Destination", "DestinationLatitude");
        }
    }
}
