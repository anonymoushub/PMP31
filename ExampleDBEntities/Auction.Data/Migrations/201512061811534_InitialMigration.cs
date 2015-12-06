namespace Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Password = c.String(),
                        PasswordSalt = c.String(),
                        Email = c.String(),
                        Cash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Auction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id)
                .Index(t => t.Auction_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        Sold = c.Boolean(nullable: false),
                        AboutPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductType = c.Int(nullable: false),
                        ProductQuality = c.Int(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.UserRoleUsers",
                c => new
                    {
                        UserRole_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRole_Id, t.User_Id })
                .ForeignKey("dbo.UserRoles", t => t.UserRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.UserRole_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Auction_Id", "dbo.Auctions");
            DropForeignKey("dbo.UserRoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoleUsers", "UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.UserRoleUsers", new[] { "User_Id" });
            DropIndex("dbo.UserRoleUsers", new[] { "UserRole_Id" });
            DropIndex("dbo.Products", new[] { "Owner_Id" });
            DropIndex("dbo.Users", new[] { "Auction_Id" });
            DropIndex("dbo.Auctions", new[] { "Product_Id" });
            DropTable("dbo.UserRoleUsers");
            DropTable("dbo.Products");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Auctions");
        }
    }
}
