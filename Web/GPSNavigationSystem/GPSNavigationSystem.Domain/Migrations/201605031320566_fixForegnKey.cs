namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixForegnKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceProvider", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.House", "DestinationID", "dbo.Destination");
            DropForeignKey("dbo.House", "StreetID", "dbo.Street");
            DropIndex("dbo.ServiceProvider", new[] { "CategoryID" });
            DropIndex("dbo.House", new[] { "DestinationID" });
            DropIndex("dbo.House", new[] { "StreetID" });
            AlterColumn("dbo.ServiceProvider", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.House", "DestinationID", c => c.Int(nullable: false));
            AlterColumn("dbo.House", "StreetID", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceProvider", "CategoryID");
            CreateIndex("dbo.House", "DestinationID");
            CreateIndex("dbo.House", "StreetID");
            AddForeignKey("dbo.ServiceProvider", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.House", "DestinationID", "dbo.Destination", "DestinationID", cascadeDelete: true);
            AddForeignKey("dbo.House", "StreetID", "dbo.Street", "StreetID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.House", "StreetID", "dbo.Street");
            DropForeignKey("dbo.House", "DestinationID", "dbo.Destination");
            DropForeignKey("dbo.ServiceProvider", "CategoryID", "dbo.Category");
            DropIndex("dbo.House", new[] { "StreetID" });
            DropIndex("dbo.House", new[] { "DestinationID" });
            DropIndex("dbo.ServiceProvider", new[] { "CategoryID" });
            AlterColumn("dbo.House", "StreetID", c => c.Int());
            AlterColumn("dbo.House", "DestinationID", c => c.Int());
            AlterColumn("dbo.ServiceProvider", "CategoryID", c => c.Int());
            CreateIndex("dbo.House", "StreetID");
            CreateIndex("dbo.House", "DestinationID");
            CreateIndex("dbo.ServiceProvider", "CategoryID");
            AddForeignKey("dbo.House", "StreetID", "dbo.Street", "StreetID");
            AddForeignKey("dbo.House", "DestinationID", "dbo.Destination", "DestinationID");
            AddForeignKey("dbo.ServiceProvider", "CategoryID", "dbo.Category", "CategoryID");
        }
    }
}
