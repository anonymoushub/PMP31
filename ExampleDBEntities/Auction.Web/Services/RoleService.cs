using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Auction.Data.Repository;
using Auction.Model;
using Auction.Model.Enums;

namespace Auction.Web.Services
{
    public class RoleService
    {
        public static ICollection<UserRole> GetUserRoles(string userEmail)
        {
            var userRepository = DependencyResolver.Current.GetService<IUserRepository>();
            var user = userRepository.GetUserByEmail(userEmail);
            return user.UserRoles;
        }

        public static bool IsAuctionRealtor(string userEmail)
        {
            var user = GetUser(userEmail);
            return user.UserRoles.Any(ur => ur.Id == (int)Role.AuctionRealtor);
        }

        //determine if Set2 contains all of the elements in Set1
        //bool containsAll = Set1.All(s => Set2.Contains(s));
        public static bool Is(string userEmail, Role[] roles)
        {
            var user = GetUser(userEmail);
            return roles.All(r => user.UserRoles.Select(r2 => r2.Id).Contains((int)r));;
        }

        private static User GetUser(string email)
        {
            var userRepository = DependencyResolver.Current.GetService<IUserRepository>();
            return userRepository.GetUserByEmail(email);
        }
    }
}