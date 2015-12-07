namespace Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductionYearToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Year");
        }
    }
}
