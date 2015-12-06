using System.Linq;
using System.Data.Entity;
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
            return _auctionDbContext.Users.Include(u => u.UserRoles)
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public bool UserInRole(int userId, int roleId)
        {
            return GetById(userId).UserRoles.Any(r => r.Id == roleId);
        }

        public void CreateUser(User u)
        {
            _auctionDbContext.Users.Add(u);
        }

        public User GetById(int id)
        {
            return _auctionDbContext.Users.Include(u => u.UserRoles)
                    .FirstOrDefault(u => u.Id == id);
        }
    }
}
