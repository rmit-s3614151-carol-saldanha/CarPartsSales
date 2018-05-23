using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OAuthExample.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAuthExample.Models.ShoppingCartViewModels;

namespace OAuthExample.Models
{
    public class ShoppingCart
    {

        private readonly Assignment2Context _context;

        private ShoppingCart(Assignment2Context context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }

        public List<Cart> ShoppingCartItems { get; set;  }

        public static ShoppingCart GetCart(IServiceProvider services)
        {

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
               .HttpContext.Session;

            var context = services.GetService<Assignment2Context>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
            
        }

        public void AddToCart(Product product, double amount)
        {
            var shoppingCartItem =
                _context.ShoppingCartItems.SingleOrDefault(
                    s => s.Product.ProductID == product.ProductID && s.ShoppingCartID == ShoppingCartId );

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new Cart
                {
                    ShoppingCartID = ShoppingCartId,
                    Product = product,
                    Amount = amount
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public double RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                  _context.ShoppingCartItems.SingleOrDefault(
                      s => s.Product.ProductID == product.ProductID && s.ShoppingCartID == ShoppingCartId);

            double localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<Cart> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                    _context.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartId)
                    .Include(s => s.Product)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context
                .ShoppingCartItems
                .Where(c => c.ShoppingCartID == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartId)
                                .Select(c => c.Product.Price).Sum();
            return total;
        }
    }
}