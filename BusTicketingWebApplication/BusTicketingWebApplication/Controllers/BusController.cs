using Microsoft.AspNetCore.Mvc;

namespace BusTicketingWebApplication.Controllers
{
    public class BusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
