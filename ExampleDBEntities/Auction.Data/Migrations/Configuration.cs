using System.Collections.Generic;
using Auction.Model;
using Auction.Model.Serializer;

namespace Auction.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Auction.Data.AuctionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Auction.Data.AuctionDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var simpleUserRole = new UserRole {Name = "SimpleUser"};
            var adminUserRole = new UserRole {Name = "Admin"};
            var auctionRealtorUserRole = new UserRole {Name = "AuctionRealtor"};

            context.UserRoles.AddOrUpdate(r => r.Id,
                simpleUserRole, adminUserRole, auctionRealtorUserRole);

            context.Users.AddOrUpdate(u=>u.Id,
               new User {
                    FirstName = "Sanya",
                    LastName = "Kaser",
                    Email = "test.test@gmail.com",
                    Password = "EMPTY",
                    PasswordSalt = "EMPTY",
                    Cash = 1000,
                    Gender = Gender.Male,
                    UserRoles = new List<UserRole> { adminUserRole, auctionRealtorUserRole }
                });
        }
    }
}
