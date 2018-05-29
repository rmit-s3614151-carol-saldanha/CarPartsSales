using System;
using System.Collections.Generic;
using OAuthExample.Models;

namespace Assignment2.Models.Interfaces
{
    public class IOrderHistoryRepository
    {

        public IEnumerable<Order> orders { get; set; }
        public IEnumerable<OrderDetail> orderDetails { get; set; }

    }
}