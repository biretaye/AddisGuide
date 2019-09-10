namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StationDestination", "StationLocation_StationLocationID", "dbo.StationLocation");
            DropIndex("dbo.StationDestination", new[] { "StationLocation_StationLocationID" });
            RenameColumn(table: "dbo.StationDestination", name: "StationLocation_StationLocationID", newName: "StationLocationID");
            AlterColumn("dbo.StationDestination", "StationLocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.StationDestination", "StationLocationID");
            AddForeignKey("dbo.StationDestination", "StationLocationID", "dbo.StationLocation", "StationLocationID", cascadeDelete: true);
            DropColumn("dbo.StationDestination", "StationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StationDestination", "StationID", c => c.Int(nullable: false));
            DropForeignKey("dbo.StationDestination", "StationLocationID", "dbo.StationLocation");
            DropIndex("dbo.StationDestination", new[] { "StationLocationID" });
            AlterColumn("dbo.StationDestination", "StationLocationID", c => c.Int());
            RenameColumn(table: "dbo.StationDestination", name: "StationLocationID", newName: "StationLocation_StationLocationID");
            CreateIndex("dbo.StationDestination", "StationLocation_StationLocationID");
            AddForeignKey("dbo.StationDestination", "StationLocation_StationLocationID", "dbo.StationLocation", "StationLocationID");
        }
    }
}
