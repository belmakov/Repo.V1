using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DashBoard.Controllers
{
    public class AreasController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;

        public AreasController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }

        public IActionResult Index()
        {
            var areas = _adminDatabaseContext.Areas.Include(a => a.City)
                .Select(a => new AreaViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    CityName = a.City.Name
                });
            return View(areas);
        }

        public IActionResult SubAreaIndex(Guid id, string name)
        {
            var subAreas = _adminDatabaseContext.SubAreas.Include(a => a.Area).Where(s => s.Area.Id == id)
                .Select(a => new SubAreaViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    AreaName = a.Area.Name
                });
            return View(subAreas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CITY_NAMES"] = new SelectList(Cities, "Value", "Text");
            return View();
        }

        private IEnumerable<SelectListItem> Cities =>
             _adminDatabaseContext.Cities.Select
                (c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

        [HttpPost]
        public IActionResult Create(AreaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (_adminDatabaseContext.Areas.Any(a =>
                a.Name.Equals(viewModel.Name) && a.City.Id == viewModel.CityId))
            {
                ModelState.AddModelError("", "An area with this name already exists!");
                ViewData["CITY_NAMES"] = Cities;
                return View();
            }
            var area = new Area
            {
                Name = viewModel.Name,
                City = _adminDatabaseContext.Cities.First(c => c.Id == viewModel.CityId)
            };
            _adminDatabaseContext.Areas.Add(area);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var area = _adminDatabaseContext.Areas.Include(a => a.City).First(a => a.Id == id);
            var cities = Cities.ToList();
            var viewModel = new AreaViewModel
            {
                Id = area.Id,
                Name = area.Name,
                CityName = area.City.Name,
                Cities = Cities,
                CityId = area.City.Id
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(AreaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (_adminDatabaseContext.Areas.Any(a =>
                            a.Name.Equals(viewModel.Name) && a.City.Id == viewModel.CityId))
                return View(viewModel);
            var area = _adminDatabaseContext.Areas.First(a => a.Id == viewModel.CityId);
            area.Name = viewModel.Name;
            area.City = _adminDatabaseContext.Cities.First(c => c.Id == viewModel.CityId);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var area = _adminDatabaseContext.Areas.Include(a => a.City).First(a => a.Id == id);
            return View(new AreaViewModel
            {
                CityId = id,
                Name = area.Name,
                CityName = area.City.Name
            });
        }

        [HttpPost]
        public IActionResult Delete(AreaViewModel areaViewModel)
        {
            var area = _adminDatabaseContext.Areas.First(a => a.Id == areaViewModel.CityId);
            _adminDatabaseContext.Areas.Remove(area);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SubAreas()
        {
            return RedirectToAction("SubAreasUnderArea", "SubAreas");
        }
    }
}