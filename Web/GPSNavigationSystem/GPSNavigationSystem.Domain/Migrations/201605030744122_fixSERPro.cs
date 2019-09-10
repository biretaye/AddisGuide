namespace GPSNavigationSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixSERPro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderLatitude", c => c.Double(nullable: false));
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderLongitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderLongitude", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceProviderLocation", "ServiceProviderLatitude", c => c.Int(nullable: false));
        }
    }
}
