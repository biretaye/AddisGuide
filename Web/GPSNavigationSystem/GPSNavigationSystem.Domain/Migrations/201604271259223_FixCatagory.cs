namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCatagory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "CategoryName", c => c.String(nullable: false));
            DropColumn("dbo.Category", "CatagoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "CatagoryName", c => c.String(nullable: false));
            DropColumn("dbo.Category", "CategoryName");
        }
    }
}
