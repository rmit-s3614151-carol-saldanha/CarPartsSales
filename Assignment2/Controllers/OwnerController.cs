﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OAuthExample.Models;
using OAuthExample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace OAuthExample.Controllers
{
    [Authorize(Roles = Constants.Owner)]
    public class OwnerController : Controller
    {
        private readonly Assignment2Context _context;

        public OwnerController(Assignment2Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Owner(string productName)
        {
            // Eager loading the Product table - join between OwnerInventory and the Product table.
            var query = _context.OwnerInventory.Include(x => x.Product).Select(x => x);

            if (!string.IsNullOrWhiteSpace(productName))
            {
                // Adding a where to the query to filter the data.
                // Note for the first request productName is null thus the where is not always added.
                query = query.Where(x => x.Product.Name.Contains(productName));

                // Storing the search into ViewBag to populate the textbox with the same value for convenience.
                ViewBag.ProductName = productName;
            }

            // Adding an order by to the query for the Product name.
            query = query.OrderBy(x => x.Product.Name);

            // Passing a List<OwnerInventory> model object to the View.
            return View(await query.ToListAsync());
        }

        public async Task<IActionResult> Sidebar(string productName)
        {
          
     

            // Passing a List<OwnerInventory> model object to the View.
            return View();
        }

        public async Task<IActionResult> ResetStock(string productName)
        {



            // Passing a List<OwnerInventory> model object to the View.
            return View();
        }

        public async Task<IActionResult> StockReq(string productName)
        {



            // Passing a List<OwnerInventory> model object to the View.
            return View();
        }
    }
}
