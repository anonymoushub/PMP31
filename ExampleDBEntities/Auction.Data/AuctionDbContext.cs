using System.Data.Entity;
using System.Diagnostics;

namespace Auction.Data
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AuctionDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Debug.WriteLine(modelBuilder.Configurations);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Model.User> Users { get; set; }
        public DbSet<Model.Auction> Auctions { get; set; }
        public DbSet<Model.Product> Products { get; set; }
        public DbSet<Model.UserRole> UserRoles { get; set; }
    }
}
