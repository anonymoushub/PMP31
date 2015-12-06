namespace Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApprovedByToAuctionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "Approved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Auctions", "ApprovedById", c => c.Int(nullable: false));
            CreateIndex("dbo.Auctions", "ApprovedById");
            AddForeignKey("dbo.Auctions", "ApprovedById", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "ApprovedById", "dbo.Users");
            DropIndex("dbo.Auctions", new[] { "ApprovedById" });
            DropColumn("dbo.Auctions", "ApprovedById");
            DropColumn("dbo.Auctions", "Approved");
        }
    }
}
