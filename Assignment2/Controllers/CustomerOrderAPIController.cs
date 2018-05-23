using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;

using OAuthExample.Data;
using OAuthExample.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Controllers
{
    [Route("api/orders")]
    public class CustomerOrderAPIController : Controller
    {
        private readonly Assignment2Context _context;

        public CustomerOrderAPIController(Assignment2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerOrder>> Get()
        {
            return  _context.CustomerOrder.ToList<CustomerOrder>();
        }



    }
}
