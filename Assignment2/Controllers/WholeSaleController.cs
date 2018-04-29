using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAuthExample.Data;

namespace OAuthExample.Controllers
{
    [Authorize(Roles = Constants.WholeSaleRole)]
    public class WholeSaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
