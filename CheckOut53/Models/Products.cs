using System;

namespace CheckOut53.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public string SpecialOffers { get; set; }

        //Brings back the data to display 
        public static Products[] GetValue()
        {
            Products[] products = new Products[]
    {

            new Products { Id= 1, Sku = "A99", Description = "Apple ",  Price = 0.50 ,SpecialOffers = "3 for 1.30" },
            new Products { Id = 2, Sku = "B15", Description = "Biscuit", Price = 0.30, SpecialOffers = "2 for 0.45" },
            new Products { Id = 3, Sku = "C40", Description = "Coffee",  Price = 1.80 },
            new Products { Id= 4, Sku = "T23", Description = "Tissues",  Price = 0.99 }
    };
            return products;
        }
    }
}
