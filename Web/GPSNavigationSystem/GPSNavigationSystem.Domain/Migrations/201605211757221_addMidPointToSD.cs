namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMidPointToSD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MidPoint", "MidPointID", "dbo.StationDestination");
            DropIndex("dbo.MidPoint", new[] { "MidPointID" });
            AddColumn("dbo.StationDestination", "MidPointLatitude", c => c.Double());
            AddColumn("dbo.StationDestination", "MidPointLongitude", c => c.Double());
            DropColumn("dbo.StationDestination", "MidPointID");
            DropTable("dbo.MidPoint");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MidPoint",
                c => new
                    {
                        MidPointID = c.Int(nullable: false),
                        MidPointName = c.String(nullable: false),
                        MidPointLatitude = c.Double(),
                        MidPointLongitude = c.Double(),
                    })
                .PrimaryKey(t => t.MidPointID);
            
            AddColumn("dbo.StationDestination", "MidPointID", c => c.Int());
            DropColumn("dbo.StationDestination", "MidPointLongitude");
            DropColumn("dbo.StationDestination", "MidPointLatitude");
            CreateIndex("dbo.MidPoint", "MidPointID");
            AddForeignKey("dbo.MidPoint", "MidPointID", "dbo.StationDestination", "StationDestinationID");
        }
    }
}
