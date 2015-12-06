using System;
using System.Collections.Generic;

namespace Auction.Model
{
    public class Auction : IModel
    {
        public Auction()
        {
            PotentialBuyers = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<User> PotentialBuyers { get; set; }

    }
}
