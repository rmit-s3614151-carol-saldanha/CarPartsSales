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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Controllers
{   [Route("api/orderhistory")]
    public class OrderHistoryAPIController : Controller
    {
        private readonly Assignment2Context _context;

        public OrderHistoryAPIController(Assignment2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderHistory>> Get()
        {
            return _context.OrderHistory.ToList<OrderHistory>();
        }


        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderHistory>> Get(int id){

            return _context.OrderHistory.Where(x => x.ReceiptID == id).ToList<OrderHistory>();
        }
    }
}
