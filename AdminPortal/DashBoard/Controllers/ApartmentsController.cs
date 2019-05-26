using System;
using System.Collections.Generic;
using System.Linq;
using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;

        public ApartmentsController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var apartment = _adminDatabaseContext.Flats.Include(f => f.Block).ThenInclude(b => b.Community)
                .First(b => b.Id == id);
            //ViewData["BLOCK_NAMES"] = new SelectList(Blocks(apartment.Block.Community.Id), "Value", "Text", new SelectListItem
            //{
            //    Value = apartment.Block.Id.ToString(),
            //    Text = apartment.Block.Name
            //});
            return View("Views/Communities/Apartments/Edit.cshtml",
                new ApartMentViewModel
                {
                    IsRented = apartment.IsRented,
                    ApartMentId = apartment.Id,
                    Number = apartment.Number,
                    CommunityId = apartment.Block.Community.Id,
                    BlockNames = Blocks(apartment.Block.Community.Id).ToList(),
                    BlockId = apartment.Block.Id
                });
        }

        [HttpPost]
        public IActionResult Edit(ApartMentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var apartment = _adminDatabaseContext.Flats.Include(b => b.Block).First(f => f.Id == model.ApartMentId);
                apartment.Number = model.Number;
                apartment.IsRented = model.IsRented;
                if (apartment.Block.Id != model.BlockId)
                {
                    apartment.Block = _adminDatabaseContext.Blocks.First(b => b.Id == model.BlockId);
                }
                _adminDatabaseContext.SaveChanges();
                return RedirectToAction("Details", "Communities", new {communityId = model.CommunityId});
            }
            ViewData["BLOCK_NAMES"] = new SelectList(Blocks(model.CommunityId), "Value", "Text");
            return View("Views/Communities/Apartments/Edit.cshtml", model);
        }

        [HttpGet]
        public IActionResult Create(Guid communityId)
        {
            var model = new ApartMentViewModel{CommunityId = communityId};
            ViewData["BLOCK_NAMES"] = new SelectList(Blocks(communityId), "Value", "Text");
            return View("Views/Communities/Apartments/Create.cshtml", model);
        }

        [HttpPost]
        public IActionResult Create(ApartMentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var block = _adminDatabaseContext.Blocks.Include(b => b.Community).First(b => b.Id == model.BlockId);
                var flat = new Unit
                {
                    Number = model.Number,
                    IsRented = model.IsRented,
                    Block = block
                };
                _adminDatabaseContext.Flats.Add(flat);
                _adminDatabaseContext.SaveChanges();
                return RedirectToAction("Details", "Communities", new {communityId = block.Community.Id});
            }
            return View("Views/Communities/Apartments/Create.cshtml", model);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var apartment = _adminDatabaseContext.Flats.Include(f => f.Block).ThenInclude(b => b.Community).First(f => f.Id == id);
            return View("Views/Communities/Apartments/Delete.cshtml", new ApartMentViewModel
            {
                Number = apartment.Number,
                BlockName = apartment.Block.Name,
                CommunityId = apartment.Block.Community.Id,
                ApartMentId = id
            });
        }

        [HttpPost]
        public IActionResult Delete(ApartMentViewModel model)
        {
            var apartment = _adminDatabaseContext.Flats.Include(f => f.Block).ThenInclude(b => b.Community)
                .First(f => f.Id == model.ApartMentId);
            _adminDatabaseContext.Flats.Remove(apartment);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Details", "Communities",
                new {communityId = apartment.Block.Community.Id});
        }

        private IEnumerable<SelectListItem> Blocks(Guid communityId) =>
            _adminDatabaseContext.Communities.Include(c => c.Blocks)
                .AsNoTracking()
                .First(c => c.Id == communityId).Blocks
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                });
    }
}