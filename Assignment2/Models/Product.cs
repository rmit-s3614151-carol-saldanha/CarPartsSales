using System;

namespace OAuthExample.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Uri Image { get; set;  }
    }
}
