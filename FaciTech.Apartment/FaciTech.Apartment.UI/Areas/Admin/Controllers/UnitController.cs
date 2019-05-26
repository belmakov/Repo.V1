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
        public JsonResult Get(int communityId)
        {
            var units = _context.Unit.Include(e=>e.Block).Where(e => e.Block.CommunityId == communityId).ToList();
            List<UnitViewModel> unitViewModels = new List<UnitViewModel>();
            foreach (var unit in units)
            {
                unitViewModels.Add(new UnitViewModel()
                {
                    id = unit.Id.ToString(),
                    flat = unit.UnitNumber,
                    floor_number = unit.FloorNumber,
                    block = unit.Block.BlockName,
                    block_id = unit.Block.Id,
                    specification = unit.Specification
                });
            }
            return Json(new ResponseModel(ResponseStatus.Success, "", unitViewModels));
        }
        public JsonResult Save([FromBody]UnitViewModel unitViewModel)
        {
            var blockId = _context.Block.Where(e => e.BlockName == unitViewModel.block).Select(e=>e.Id).FirstOrDefault();
            Unit unit = new Unit();
            unit.BlockId =  unitViewModel.block_id;
            unit.FloorNumber = unitViewModel.floor_number;
            unit.UnitNumber = unitViewModel.flat;
            unit.Specification = unitViewModel.specification;

            if (unitViewModel.id == null || unitViewModel.id == "")
            {
                _context.Add(unit);
            }
            else
            {
                unit.Id = Int32.Parse(unitViewModel.id);
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