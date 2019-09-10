namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMidPoint1 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MidPoint");
        }
    }
}
