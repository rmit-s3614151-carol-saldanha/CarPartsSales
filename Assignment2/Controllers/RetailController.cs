using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAuthExample.Data;

namespace OAuthExample.Controllers
{
    [Authorize(Roles = Constants.RetailRole)]
    public class RetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
