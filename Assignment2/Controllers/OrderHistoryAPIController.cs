using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAuthExample.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OAuthExample.Models;
using OAuthExample.Models.ShoppingCartViewModels;
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
        public async Task<IEnumerable<OrderDetail>> Get()
        {
            return _context.OrderDetails.ToList<OrderDetail>();
        }


        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderDetail>> Get(int id){

            return _context.OrderDetails.Where(x => x.OrderDetailId == id).ToList<OrderDetail>();
        }
    }
}
