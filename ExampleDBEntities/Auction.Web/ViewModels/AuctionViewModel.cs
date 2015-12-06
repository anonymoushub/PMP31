using System;
using System.Collections.Generic;
using Auction.Model;

namespace Auction.Web.ViewModels
{
    public class AuctionViewModel 
    {
        public AuctionViewModel()
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
