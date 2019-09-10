namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDestinationFromHouses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.House", "DestinationID", "dbo.Destination");
            DropIndex("dbo.House", new[] { "DestinationID" });
            DropColumn("dbo.House", "DestinationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.House", "DestinationID", c => c.Int(nullable: false));
            CreateIndex("dbo.House", "DestinationID");
            AddForeignKey("dbo.House", "DestinationID", "dbo.Destination", "DestinationID", cascadeDelete: true);
        }
    }
}
