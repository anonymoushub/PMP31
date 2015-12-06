using System.Collections.Generic;
using Auction.Model;
using Auction.Model.Enums;

namespace Auction.Web.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }

        public decimal Cash { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}