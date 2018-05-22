using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthExample.Models
{
    public class Cart
    {
        [Key]
        public int ShoppingCartItemID { get; set; }

        public Product Product { get; set; }

        public double Amount { get; set; }

        public string ShoppingCartID { get; set; }
    }
}