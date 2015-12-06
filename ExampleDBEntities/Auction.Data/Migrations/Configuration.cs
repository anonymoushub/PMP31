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
            var simpleUserRole = new UserRole {Name = "SimpleUser"};
            var adminUserRole = new UserRole {Name = "Admin"};
            var auctionRealtorUserRole = new UserRole {Name = "AuctionRealtor"};

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
                });
        }
    }
}
