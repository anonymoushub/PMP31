using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

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

        public bool Approved { get; set; }

        [ForeignKey("ApprovedBy")]
        public int ApprovedById { get; set; }
        public User ApprovedBy { get; set; }
    }
}
