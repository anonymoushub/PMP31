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
            var userRepository = DependencyResolver.Current.GetService<IUserRepository>();
            var user = userRepository.GetUserByEmail(userEmail);
            return user.UserRoles.Any(ur => ur.Id == (int)Role.AuctionRealtor);
        }

        //determine if Set2 contains all of the elements in Set1
        //bool containsAll = Set1.All(s => Set2.Contains(s));
        //public static bool Is(string userEmail, List<string> roles)
        //{
        //    var userRepository = DependencyResolver.Current.GetService<IUserRepository>();
        //    var user = userRepository.GetUserByEmail(userEmail);
        //    bool flag = roles.All(r => user.UserRoles.Contains(r));
        //    return flag;
        //}

    }
}