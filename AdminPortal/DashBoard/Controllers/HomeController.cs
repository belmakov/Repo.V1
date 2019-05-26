using System.Collections.Generic;
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
            PopulateInitialDataIfRequired();
        }

        private void PopulateInitialDataIfRequired()
        {
            if (!_adminDatabaseContext.States.Any())
            {
                var states = new List<State>
                {
                    new State
                    {
                        Country = "India",
                        Name = "Karnataka",
                        Cities = new List<City>
                        {
                            new City
                            {
                                Name = "Bangalore"
                            },
                            new City
                            {
                                Name = "Mysore"
                            },
                            new City
                            {
                                Name = "Mangalore"
                            }

                        }
                    }
                };
                _adminDatabaseContext.States.AddRange(states);
                _adminDatabaseContext.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
