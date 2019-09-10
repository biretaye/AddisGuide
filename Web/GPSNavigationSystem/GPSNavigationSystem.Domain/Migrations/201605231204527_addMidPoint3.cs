namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMidPoint3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MidPoint",
                c => new
                    {
                        MidPointID = c.Int(nullable: false, identity: true),
                        MidPointName = c.String(nullable: false),
                        MidPointLatitude = c.Double(),
                        MidPointLongitude = c.Double(),
                    })
                .PrimaryKey(t => t.MidPointID);
            
            AddColumn("dbo.StationDestination", "MidPointID", c => c.Int());
            CreateIndex("dbo.StationDestination", "MidPointID");
            AddForeignKey("dbo.StationDestination", "MidPointID", "dbo.MidPoint", "MidPointID");
            DropColumn("dbo.StationDestination", "MidPointLatitude");
            DropColumn("dbo.StationDestination", "MidPointLongitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StationDestination", "MidPointLongitude", c => c.Double());
            AddColumn("dbo.StationDestination", "MidPointLatitude", c => c.Double());
            DropForeignKey("dbo.StationDestination", "MidPointID", "dbo.MidPoint");
            DropIndex("dbo.StationDestination", new[] { "MidPointID" });
            DropColumn("dbo.StationDestination", "MidPointID");
            DropTable("dbo.MidPoint");
        }
    }
}
