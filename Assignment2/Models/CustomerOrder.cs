using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OAuthExample.Models
{
    public class CustomerOrder
    {

        [Key]
        public int ReceiptID { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
