using FaciTech.Apartment.Database;
using FaciTech.Apartment.Database.Models;
using FaciTech.Apartment.UI.Areas.Admin.Models;
using FaciTech.Apartment.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaciTech.Apartment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UnitController : Controller
    {
        private readonly FaciTechContext _context;
        public UnitController(FaciTechContext context)
        {
            _context = context;
        }
        public JsonResult Get(Guid communityId)
        {
            var units = _context.Unit.Include(e=>e.Section).Where(e => e.Section.CommunityId == communityId).ToList();
            List<UnitViewModel> unitViewModels = new List<UnitViewModel>();
            foreach (var unit in units)
            {
                unitViewModels.Add(new UnitViewModel()
                {
                    id = unit.Id.ToString(),
                    flat = unit.Number,
                    floor_number = unit.FloorNumber,
                    block = unit.Section.Name,
                    block_id = unit.Section.Id,
                    specification = unit.Specification
                });
            }
            return Json(new ResponseModel(ResponseStatus.Success, "", unitViewModels));
        }
        public JsonResult Save([FromBody]UnitViewModel unitViewModel)
        {
            var blockId = _context.Block.Where(e => e.Name == unitViewModel.block).Select(e=>e.Id).FirstOrDefault();
            Unit unit = new Unit();
            unit.SectionId =  unitViewModel.block_id;
            unit.FloorNumber = unitViewModel.floor_number;
            unit.Number = unitViewModel.flat;
            unit.Specification = unitViewModel.specification;

            if (unitViewModel.id == null || unitViewModel.id == "")
            {
                _context.Add(unit);
            }
            else
            {
                unit.Id = Guid.Parse(unitViewModel.id);
                _context.Update(unit);
            }
            _context.SaveChanges();
            unitViewModel.id = unit.Id.ToString();
            return Json(new ResponseModel(ResponseStatus.Success, "", unit));
        }
        private int GetFloorNumber(string floor)
        {
            if (floor.ToLowerInvariant() == "ground floor")
            {
                return 0;
            }
            return Int32.Parse(floor.Split(" ")[0].Replace("st", "").Replace("nd", "").Replace("rd", "").Replace("th", ""));
        }
    }
}