using System;

namespace Auction.Model
{
    public class Product : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Sold { get; set; }

        // Owner of the Product set the AboutPrice 
        // Satisfying price for sold
        public decimal AboutPrice { get; set; }

        public ProductType ProductType { get; set; }
        public ProductQuality ProductQuality { get; set; }
        
        public virtual User Owner { get; set; }
    }

    public enum ProductQuality
    {
        Perfect = 0,
        Good = 1,
        Normal = 2,
        Bad = 3,
        Awful = 4
    }

    public enum ProductType
    {
        Auto = 0,
        Motorcycle = 1,
        Scooter = 2,
        Bike = 3
    }
}
