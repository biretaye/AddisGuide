namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class destinationLongLat : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Destination", "DestinationLatitude");
            DropColumn("dbo.Destination", "DestinationLongitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Destination", "DestinationLongitude", c => c.Double());
            AddColumn("dbo.Destination", "DestinationLatitude", c => c.Double());
        }
    }
}
