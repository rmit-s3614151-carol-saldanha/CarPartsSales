﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthExample.Models.OwnerInventory
{
    public class OwnerInventory
    {
        [Key, ForeignKey("Product"), Display(Name = "Product ID")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Display(Name = "Stock Level")]
        public int StockLevel { get; set; }
    }
}
