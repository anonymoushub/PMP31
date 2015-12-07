using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Auction.Model;
using Auction.Model.Enums;

namespace Auction.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AuctionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuctionDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var simpleUserRole = new UserRole {Id = (int)Role.SimpleUser, Name = "SimpleUser"};
            var adminUserRole = new UserRole {Id = (int)Role.Admin,Name = "Admin"};
            var auctionRealtorUserRole = new UserRole { Id = (int)Role.AuctionRealtor, Name = "AuctionRealtor" };

            context.UserRoles.AddOrUpdate(r => r.Name,
                simpleUserRole, adminUserRole, auctionRealtorUserRole);


            context.Users.AddOrUpdate(u=>u.Email,
               new User {
                    FirstName = "Sanya",
                    LastName = "Kaser",
                    Email = "test.test@gmail.com",
                    // 123
                    Password = "e+n//s2ThIUL7ng5/7IYKL40XIj2bx4NWw1DRZhHNUpquMYuDJWNOYSxDCbdfGgmEh9wK/o5xJzR766p4rzdrw==",
                    PasswordSalt = "100000.TESd+f4VS1OyESWysEX6rg8gsbwPtTSgP2PyrZuwr/E0MA==",
                    Cash = 1000,
                    Gender = Gender.Male,
                    UserRoles = new List<UserRole> { adminUserRole, auctionRealtorUserRole }
                },
                new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin.admin@gmail.com",
                    // 123
                    Password = "e+n//s2ThIUL7ng5/7IYKL40XIj2bx4NWw1DRZhHNUpquMYuDJWNOYSxDCbdfGgmEh9wK/o5xJzR766p4rzdrw==",
                    PasswordSalt = "100000.TESd+f4VS1OyESWysEX6rg8gsbwPtTSgP2PyrZuwr/E0MA==",
                    Cash = 1000,
                    Gender = Gender.Male,
                    UserRoles = new List<UserRole> { adminUserRole }
                },
                new User
                {
                    FirstName = "Simple",
                    LastName = "Simple",
                    Email = "simple.simple@gmail.com",
                    // 123
                    Password = "e+n//s2ThIUL7ng5/7IYKL40XIj2bx4NWw1DRZhHNUpquMYuDJWNOYSxDCbdfGgmEh9wK/o5xJzR766p4rzdrw==",
                    PasswordSalt = "100000.TESd+f4VS1OyESWysEX6rg8gsbwPtTSgP2PyrZuwr/E0MA==",
                    Cash = 1000,
                    Gender = Gender.Male,
                    UserRoles = new List<UserRole> { simpleUserRole }
                });

            PopulateProducts(context);
        }

        private void PopulateProducts(AuctionDbContext context)
        {
            Product car1 = new Product
            {
                Name = "Aston Martin Vulcan 2016",
                AboutPrice = 2300000,
                DateAdded = DateTime.Now,
                ImageUrl = "/Content/img/a.jpg",
                ProductQuality = ProductQuality.Perfect,
                ProductType = ProductType.Auto,
                Sold = false
            };

            Product car2 = new Product
            {
                Name = "Porsche Cayenne Turbo Mansory 2015",
                AboutPrice = 350000,
                DateAdded = DateTime.Now,
                ImageUrl = "/Content/img/p.jpg",
                ProductQuality = ProductQuality.Good,
                ProductType = ProductType.Auto,
                Sold = false
            };

            Product car3 = new Product
            {
                Name = "Mercedes-Benz S 63 AMG Mansory M1000 2015",
                AboutPrice = 1200000,
                DateAdded = DateTime.Now,
                ImageUrl = "/Content/img/m.jpg",
                ProductQuality = ProductQuality.Perfect,
                ProductType = ProductType.Auto,
                Sold = false
            };

            Product car4 = new Product
            {
                Name = "Bentley EXP 9 F Concept",
                AboutPrice = 1000000,
                DateAdded = DateTime.Now,
                ImageUrl = "/Content/img/b.jpg",
                ProductQuality = ProductQuality.Good,
                ProductType = ProductType.Auto,
                Sold = false
            };

            Model.Auction auc1 = new Model.Auction
            {
                Approved = false,
                Product = car1,
                Name = car1.Name,
                StartTime = new DateTime(2016, 8, 25, 15, 0, 0)
            };

            Model.Auction auc2 = new Model.Auction
            {
                Approved = false,
                Product = car2,
                Name = car2.Name,
                StartTime = new DateTime(2016, 2, 12, 20, 0, 0)
            };

            Model.Auction auc3 = new Model.Auction
            {
                Approved = false,
                Product = car3,
                Name = car3.Name,
                StartTime = new DateTime(2016, 4, 7, 18, 0, 0)
            };

            context.Products.AddOrUpdate(r => r.Name, car1, car2, car3, car4);
            context.Auctions.AddOrUpdate(a => a.Name, auc1, auc2, auc3);
        }
    }
}
