using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                    Id = a.AreaId,
                    Name = a.AreaName,
                    City = a.City.CityName
                });
            return View(areas);
        }

        public IActionResult SubAreaIndex(int id, string name)
        {
            var subAreas = _adminDatabaseContext.SubAreas.Include(a => a.Area).Where(s => s.Area.AreaId == id)
                .Select(a => new SubAreaViewModel
                {
                    Id = a.SubAreaId,
                    Name = a.SubAreaName,
                    Area = a.Area.AreaName
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
                    Value = c.CityId.ToString(),
                    Text = c.CityName
                });

        [HttpPost]
        public IActionResult Create(AreaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (_adminDatabaseContext.Areas.Any(a =>
                a.AreaName.Equals(viewModel.Name) && a.City.CityId == viewModel.CityId))
            {
                ModelState.AddModelError("", "An area with this name already exists!");
                ViewData["CITY_NAMES"] = Cities;
                return View();
            }
            var area = new Area
            {
                AreaName = viewModel.Name,
                City = _adminDatabaseContext.Cities.First(c => c.CityId == viewModel.CityId)
            };
            _adminDatabaseContext.Areas.Add(area);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var area = _adminDatabaseContext.Areas.Include(a => a.City).First(a => a.AreaId == id);
            var cities = Cities.ToList();
            var viewModel = new AreaViewModel
            {
                Id = area.AreaId,
                Name = area.AreaName,
                City = area.City.CityName,
                Cities = Cities,
                CityId = area.City.CityId
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(AreaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (_adminDatabaseContext.Areas.Any(a =>
                            a.AreaName.Equals(viewModel.Name) && a.City.CityId == viewModel.CityId))
                return View(viewModel);
            var area = _adminDatabaseContext.Areas.First(a => a.AreaId == viewModel.Id);
            area.AreaName = viewModel.Name;
            area.City = _adminDatabaseContext.Cities.First(c => c.CityId == viewModel.CityId);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var area = _adminDatabaseContext.Areas.Include(a => a.City).First(a => a.AreaId == id);
            return View(new AreaViewModel
            {
                Id = id,
                Name = area.AreaName,
                City = area.City.CityName
            });
        }

        [HttpPost]
        public IActionResult Delete(AreaViewModel areaViewModel)
        {
            var area = _adminDatabaseContext.Areas.First(a => a.AreaId == areaViewModel.Id);
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