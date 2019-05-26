using System;
using System.Linq;
using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Controllers
{
    public class BlocksController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;

        public BlocksController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var block = _adminDatabaseContext.Blocks.Include(b => b.Community).First(b => b.Id == id);
            return View("Views/Communities/BlockNames/Edit.cshtml",
                new SectionViewModel {Id = block.Id, Name = block.Name, CommunityId = block.Community.Id});
        }

        [HttpPost]
        public IActionResult Edit(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var block = _adminDatabaseContext.Blocks.Include(b => b.Community).First(b => b.Id == model.Id);
                block.Name = model.Name;
                _adminDatabaseContext.SaveChanges();
                return RedirectToAction("Details", "Communities", new {communityId = block.Community.Id});
            }
            return View("Views/Communities/BlockNames/Edit.cshtml", model);
        }

        [HttpGet]
        public IActionResult Create(Guid communityId)
        {
            var model = new SectionViewModel {CommunityId = communityId};
            return View("Views/Communities/BlockNames/Create.cshtml", model);
        }

        [HttpPost]
        public IActionResult Create(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var block = new Section
                {
                    Name = model.Name,
                    Community = _adminDatabaseContext.Communities.First(c => c.Id == model.CommunityId)
                };
                _adminDatabaseContext.Blocks.Add(block);
                _adminDatabaseContext.SaveChanges();
                return RedirectToAction("Details", "Communities", new {communityId = model.CommunityId});
            }
            return View("Views/Communities/BlockNames/Create.cshtml", model);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var block = _adminDatabaseContext.Blocks.Include(b => b.Community).First(b => b.Id == id);
            return View("Views/Communities/BlockNames/Delete.cshtml", new SectionViewModel
            {
                Id = block.Id,
                Name = block.Name,
                CommunityId = block.Community.Id
            });
        }

        [HttpPost]
        public IActionResult Delete(SectionViewModel model)
        {
            var block = _adminDatabaseContext.Blocks.Include(b => b.Community).First(b => b.Id == model.Id);
            _adminDatabaseContext.Blocks.Remove(block);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Details", "Communities", new { communityId = block.Community.Id });
        }
    }
}