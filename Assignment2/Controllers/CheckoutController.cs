using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Stripe;

namespace OAuthExample.Controllers
{
    public class CheckoutController : Controller
    {
        double total1;
        //This class makes use of Stripe API for Checkout
        public async Task<IActionResult> Index(double total)
        {
            total1 = total*100;
            ViewBag.Amount = total1;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new OAuthExample.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 100,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });
            ViewBag.Amount = total1*100;
            return View();
        }


    }
}
