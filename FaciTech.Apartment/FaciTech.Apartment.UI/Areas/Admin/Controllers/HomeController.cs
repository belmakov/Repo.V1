using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FaciTech.Apartment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Placeholder1()
        {
            return View("Dummy",1);
        }
        public IActionResult Placeholder2()
        {
            return View("Dummy",2);
        }
    }
}