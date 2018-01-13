using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;
        public HomeController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
