using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DashBoard.Controllers
{
    public class SubAreasController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;

        public SubAreasController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }

        public IActionResult Index()
        {
            var subAreas = _adminDatabaseContext.SubAreas.Include(a => a.Area)
                .Select(a => new SubAreaViewModel
                {
                    Id = a.Id,
                    Name = a.SubAreaName,
                    Area = a.Area.AreaName
                });
            return View(subAreas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["AREA_NAMES"] = new SelectList(Areas, "Value", "Text");
            return View();
        }

        private IEnumerable<SelectListItem> Areas =>
             _adminDatabaseContext.Areas.Select
                (c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.AreaName
                });

        [HttpPost]
        public IActionResult Create(SubAreaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (_adminDatabaseContext.SubAreas.Any(a =>
                a.SubAreaName.Equals(viewModel.Name) && a.Area.Id == viewModel.AreaId))
            {
                ModelState.AddModelError("", "A sub-area with this name already exists!");
                ViewData["AREA_NAMES"] = Areas;
                return View();
            }
            var subArea = new SubArea
            {
                SubAreaName = viewModel.Name,
                Area = _adminDatabaseContext.Areas.First(c => c.Id== viewModel.AreaId)
            };
            _adminDatabaseContext.SubAreas.Add(subArea);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var subArea = _adminDatabaseContext.SubAreas.Include(a => a.Area).First(a => a.Id == id);
            var viewModel = new SubAreaViewModel
            {
                Id = subArea.Id,
                Name = subArea.SubAreaName,
                Area = subArea.Area.AreaName,
                AreaId = subArea.Area.Id,
                Areas = Areas.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(SubAreaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (_adminDatabaseContext.SubAreas.Any(a =>
                            a.SubAreaName.Equals(viewModel.Name) && a.Area.Id== viewModel.AreaId))
            {
                ModelState.AddModelError("", "A sub-area with this name already exists!");
                ViewData["AREA_NAMES"] = Areas;
                return View(viewModel);
            }
            var subArea = _adminDatabaseContext.SubAreas.First(a => a.Id == viewModel.Id);
            subArea.SubAreaName = viewModel.Name;
            subArea.Area = _adminDatabaseContext.Areas.First(c => c.Id == viewModel.AreaId);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var subArea = _adminDatabaseContext.SubAreas.Include(s => s.Area).First(a => a.Id == id);
            return View(new SubAreaViewModel
            {
                Id = id,
                Name = subArea.SubAreaName,
                Area = subArea.Area.AreaName
            });
        }

        [HttpPost]
        public IActionResult Delete(SubAreaViewModel areaViewModel)
        {
            var subArea = _adminDatabaseContext.SubAreas.Include(s => s.Area).First(a => a.Id == areaViewModel.Id);
            _adminDatabaseContext.SubAreas.Remove(subArea);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SubAreasUnderArea(Guid areaId)
        {
            var subAreas = _adminDatabaseContext.SubAreas.Include(a => a.Area).Where(a => a.Area.Id == areaId)
                .Select(a => new SubAreaViewModel
                {
                    Id = a.Id,
                    Name = a.SubAreaName,
                    Area = a.Area.AreaName
                });
            return View(subAreas);
        }
    }
}