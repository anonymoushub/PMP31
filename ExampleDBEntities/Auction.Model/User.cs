using System.Collections.Generic;

namespace Auction.Model
{
    public class User
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }

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

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
