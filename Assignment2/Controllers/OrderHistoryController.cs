using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAuthExample.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OAuthExample.Models;
using OAuthExample.Models.ShoppingCartViewModels;
using OAuthExample.Data;
using Microsoft.EntityFrameworkCore;
using OAuthExample.Utility;
using Microsoft.AspNetCore.Http;
using OAuthExample.Models;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly Assignment2Context _context;

        public OrderHistoryController(Assignment2Context context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create()
        {
            CustomerOrder newOrder = new CustomerOrder();
            newOrder.Email = "carolsaldanha26@gmail.com";
            newOrder.Date = DateTime.Now;
            _context.Add(newOrder);
            await _context.SaveChangesAsync();
            _context.Entry(newOrder).GetDatabaseValues();
            var receiptID = newOrder.ReceiptID;

            List<Cart> shoppingList = new List<Cart>();

            foreach (var session in HttpContext.Session.Keys)
            {
                Cart cart = HttpContext.Session.Get<Cart>(session);

                //Cart shopping = HttpContext.Session.Get<Cart>(session);

                shoppingList.Add(cart);
            }

            OrderHistory order = new OrderHistory();
            foreach (Cart cart in shoppingList)
            {
                order = new OrderHistory();
                order.ReceiptID = receiptID;
                order.ProductName = cart.Product.Name;
                order.Image = cart.Product.Image;
                order.Quantity = (int)cart.Amount;
                 _context.Add(order);
               

                // var storeContext = _context.StoreInventory.Where(x => x.ProductID == productID).Select(x => x).First();
                // storeContext.StockLevel += stockRequestToUpdate.Quantity;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}

