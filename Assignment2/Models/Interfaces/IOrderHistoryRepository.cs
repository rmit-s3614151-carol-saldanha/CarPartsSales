using System;
using System.Collections.Generic;
using OAuthExample.Models;

namespace Assignment2.Models.Interfaces
{
    public class IOrderHistoryRepository
    {
       
            public IEnumerable<CustomerOrder> customerOrders { get; set; }
            public IEnumerable<OrderHistory> orderHistories { get; set; }

    }
}