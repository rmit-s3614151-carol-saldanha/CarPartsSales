using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAuthExample.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OAuthExample.Models;
using Microsoft.EntityFrameworkCore;
using OAuthExample.Utility;
using Microsoft.AspNetCore.Http;

namespace OAuthExample.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Assignment2Context _context;

        public CustomerController(Assignment2Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Home(string productName)
        {

                   return View();
        }

        public async Task<IActionResult> Customer(
            string sortOrder, string currentFilter,
            string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["StoreSortParm"] = sortOrder == "Store" ? "store_desc" : "Store";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;



            var query = _context.StoreInventory
                                .Include(x => x.Product)
                                .Include(x => x.Store)
                                .Select(x => x);


            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => x.Product.Name.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Product.Name);
                    break;
                case "Store":
                    query = query.OrderBy(s => s.Store.Name);
                    break;
                case "store_desc":
                    query = query.OrderByDescending(s => s.Store.Name);
                    break;
                default:
                    query = query.OrderBy(s => s.Product.Name);
                    break;
            }

            int pageSize = 3;

            return View(await PaginatedList<StoreInventory>
                        .CreateAsync(query.AsNoTracking(), page ?? 1, pageSize));
        }


        public async Task<IActionResult> Cart(){
            
            return View();
        }

    }
}

