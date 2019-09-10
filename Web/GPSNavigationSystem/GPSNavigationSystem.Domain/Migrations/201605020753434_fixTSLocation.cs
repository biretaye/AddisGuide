namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixTSLocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrafficSignLocation", "TSLocationStartLatitude", c => c.Double(nullable: false));
            AlterColumn("dbo.TrafficSignLocation", "TSLocationStartLongitude", c => c.Double(nullable: false));
            AlterColumn("dbo.TrafficSignLocation", "TSLocationEndLatitude", c => c.Double(nullable: false));
            AlterColumn("dbo.TrafficSignLocation", "TSLocationEndLongitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrafficSignLocation", "TSLocationEndLongitude", c => c.Double());
            AlterColumn("dbo.TrafficSignLocation", "TSLocationEndLatitude", c => c.Double());
            AlterColumn("dbo.TrafficSignLocation", "TSLocationStartLongitude", c => c.Double());
            AlterColumn("dbo.TrafficSignLocation", "TSLocationStartLatitude", c => c.Double());
        }
    }
}
