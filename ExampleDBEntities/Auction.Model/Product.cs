using Auction.Model.Enums;
using System;

namespace Auction.Model
{
    public class Product : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public int Year { get; set; }
        public bool Sold { get; set; }
        public string ImageUrl { get; set; }
        // Owner of the Product set the AboutPrice 
        // Satisfying price for sold
        public decimal AboutPrice { get; set; }

        public ProductType ProductType { get; set; }
        public ProductQuality ProductQuality { get; set; }
        
        public virtual User Owner { get; set; }
    }
}
