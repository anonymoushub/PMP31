using System.Web;
using System.Web.Mvc;
using Auction.Data.Repository;
using Auction.Model;

namespace Auction.Web.Services
{
    public class UserService
    {
        public static User GetCurrentUser()
        {
            var c = HttpContext.Current;
            if (!c.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var user = (User)c.Items["CurrentUser"];
            if (user != null) return user;

            var userRepository = DependencyResolver.Current.GetService<IUserRepository>();       
            user = userRepository.GetUserByEmail(c.User.Identity.Name);
            
            // save user in context => better for performance 
            // we will fetch user from context once per request(no queries to db)
            c.Items["CurrentUser"] = user;

            return user;
        }
    }
}