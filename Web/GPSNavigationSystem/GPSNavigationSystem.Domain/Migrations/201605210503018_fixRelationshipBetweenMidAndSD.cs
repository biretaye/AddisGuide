namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixRelationshipBetweenMidAndSD : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MidPoint");
            AddColumn("dbo.StationDestination", "MidPointID", c => c.Int());
            AlterColumn("dbo.MidPoint", "MidPointID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MidPoint", "MidPointID");
            CreateIndex("dbo.MidPoint", "MidPointID");
            AddForeignKey("dbo.MidPoint", "MidPointID", "dbo.StationDestination", "StationDestinationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MidPoint", "MidPointID", "dbo.StationDestination");
            DropIndex("dbo.MidPoint", new[] { "MidPointID" });
            DropPrimaryKey("dbo.MidPoint");
            AlterColumn("dbo.MidPoint", "MidPointID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.StationDestination", "MidPointID");
            AddPrimaryKey("dbo.MidPoint", "MidPointID");
        }
    }
}
