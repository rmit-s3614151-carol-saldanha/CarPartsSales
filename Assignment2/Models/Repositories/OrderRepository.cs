using OAuthExample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAuthExample.Models;
using Microsoft.EntityFrameworkCore;
using OAuthExample.Data;


namespace OAuthExample.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Assignment2Context _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(Assignment2Context appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductID,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Product.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }

}