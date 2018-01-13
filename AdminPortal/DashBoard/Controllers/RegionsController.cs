using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashBoard.Controllers
{
    public class RegionsController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;
        public RegionsController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }
        public IActionResult Index()
        {
            return View(_adminDatabaseContext.Regions);
        }
        public IActionResult Sections(int id)
        {
            var regionName = _adminDatabaseContext.Regions.First(r => r.Id == id).Name;
            ViewData["REGION_NAME"] = regionName;
            return View("Sections", _adminDatabaseContext.Sections.Where(s => s.Region.Id == id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RegionViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (_adminDatabaseContext.Regions.Any(r => r.Name.Equals(viewModel.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return View(viewModel);
            }
            else
            {
                var region = new Region() {Name = viewModel.Name};
                _adminDatabaseContext.Regions.Add(region);
                _adminDatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var region = _adminDatabaseContext.Regions.First(r => r.Id == id);
            return View(new RegionViewModel { Name = region.Name });
        }
        [HttpPost]
        public IActionResult Edit(int id, RegionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var region = _adminDatabaseContext.Regions.First(r => r.Id == id);
            if(_adminDatabaseContext.Regions.Any(r => r.Name.Equals(viewModel.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return View(viewModel);
            }
            region.Name = viewModel.Name;
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var region = _adminDatabaseContext.Regions.First(r => r.Id == id);
            return View(new RegionViewModel { Name = region.Name, Id = region.Id });
        }
        [HttpPost]
        public IActionResult Delete(int id, RegionViewModel viewModel)
        {
            var region = _adminDatabaseContext.Regions.First(r => r.Id == id);
            _adminDatabaseContext.Regions.Remove(region);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}