using System.Linq;
using Auction.Model;

namespace Auction.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionDbContext _auctionDbContext;
        public UserRepository(AuctionDbContext auctionDbContext)
        {
            _auctionDbContext = auctionDbContext;
        }

        public IQueryable<User> GetUsers(bool isEnabled)
        {
            return _auctionDbContext.Users;
        }

        public User GetUserByEmail(string email)
        {
            return _auctionDbContext.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetById(int id)
        {
            return _auctionDbContext.Users.Find(id);
        }
    }
}
