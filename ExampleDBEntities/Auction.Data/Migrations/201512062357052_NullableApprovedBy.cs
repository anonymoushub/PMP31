namespace Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableApprovedBy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auctions", "ApprovedById", "dbo.Users");
            DropIndex("dbo.Auctions", new[] { "ApprovedById" });
            RenameColumn(table: "dbo.Auctions", name: "ApprovedById", newName: "ApprovedBy_Id");
            AlterColumn("dbo.Auctions", "ApprovedBy_Id", c => c.Int());
            CreateIndex("dbo.Auctions", "ApprovedBy_Id");
            AddForeignKey("dbo.Auctions", "ApprovedBy_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "ApprovedBy_Id", "dbo.Users");
            DropIndex("dbo.Auctions", new[] { "ApprovedBy_Id" });
            AlterColumn("dbo.Auctions", "ApprovedBy_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Auctions", name: "ApprovedBy_Id", newName: "ApprovedById");
            CreateIndex("dbo.Auctions", "ApprovedById");
            AddForeignKey("dbo.Auctions", "ApprovedById", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
