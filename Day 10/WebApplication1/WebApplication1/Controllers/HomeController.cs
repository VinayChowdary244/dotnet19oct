﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Landing() 
        {
            return View();
        }
        [ActionName("Foxy")]
        public IActionResult CannotBeTheNameInTheRequestCozItsReallyLong()
        {
            return View();
        }
    }
}
