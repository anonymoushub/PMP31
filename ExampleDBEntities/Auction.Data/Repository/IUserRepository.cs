using System.Linq;
using Auction.Model;

namespace Auction.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetUsers(bool isEnabled);
        User GetUserByEmail(string email);
        bool UserInRole(int userId, int roleId);
        void CreateUser(User u);
    }
}
