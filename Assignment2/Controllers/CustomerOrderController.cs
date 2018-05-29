using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using OAuthExample.Models;

using Assignment2.Models.Interfaces;

namespace Assignment2.Controllers
{
    public class CustomerOrderController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new IOrderHistoryRepository();
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://localhost:5000/api/orders");
                viewModel.orders = JsonConvert.DeserializeObject<List<Order>>(result);

            }

            if (id != null)
            {
                ViewData["orderId"] = id.Value;
                using (var client = new HttpClient())
                {
                    var historyResult = await client.GetStringAsync("http://localhost:5000/api/orderhistory/" + id);
                    viewModel.orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(historyResult);
                }
            }

            return View(viewModel);
        }
    }
}

