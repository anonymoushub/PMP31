using System.Collections.Generic;
using Auction.Model;

namespace Auction.Web.ViewModels
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
