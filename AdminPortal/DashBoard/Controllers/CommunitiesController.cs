using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashBoard.Controllers
{
    public class CommunitiesController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;

        public CommunitiesController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }

        public IActionResult Index()
        {
            var communities = _adminDatabaseContext.Communities.Include(c => c.SubArea)
                .Select(a => new CommunityViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    SubArea = a.SubArea.Name
                });
            return View(communities);
        }

        private IEnumerable<SelectListItem> SubAreas =>
            _adminDatabaseContext.SubAreas.Select
            (c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

        [HttpGet]
        public IActionResult Create()
        {
            //var subAreaNames = new SelectList(subAreas.Select(s => s.SubAreaName + "-" + s.Area.AreaName));
            ViewData["SUBAREA_NAMES"] = new SelectList(SubAreas, "Value", "Text");
            ;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CommunityViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (_adminDatabaseContext.Communities.Include(s => s.SubArea).Any(c =>
                c.Name.Equals(viewModel.Name, StringComparison.OrdinalIgnoreCase) &&
                c.SubArea.Id == viewModel.SubAreaId))
            {
                ViewData["SUBAREA_NAMES"] = SubAreas;
                return View(viewModel);
            }
            else
            {
                var community = new Community
                {
                    Name = viewModel.Name,
                    SubArea = _adminDatabaseContext.SubAreas.First(c => c.Id == viewModel.SubAreaId)
                };
                _adminDatabaseContext.Communities.Add(community);
                _adminDatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Details(Guid communityId)
        {
            var community = _adminDatabaseContext.Communities.Include(c => c.SubArea).ThenInclude(s => s.Area)
                .Include(c => c.Blocks).ThenInclude(b => b.Apartments)
                .First(c => c.Id == communityId);
                
            var viewModel = new CommunityViewModel
            {
                Id = communityId,
                Name = community.Name,
                SubArea = community.SubArea.Name,
                SubAreaId = community.SubArea.Id,
                SubAreas = SubAreas.ToList(),
                AreaName = community.SubArea.Area.Name,
                Blocks = community.Blocks.Select(b => new SectionViewModel
                {
                    Id = b.Id,
                    CommunityId = communityId,
                    Flats = b.Apartments,
                    Community = b.Community,
                    Name = b.Name
                })
            };
            return View(viewModel);
        }

        //[HttpPost]
        //public IActionResult Edit(CommunityViewModel viewModel)
        //{
        //    if (!ModelState.IsValid) return View(viewModel);
        //    if (_adminDatabaseContext.Communities.Include(c => c.SubArea).Any(c =>
        //                    c.SubAreaId.Equals(viewModel.SubAreaId) && c.CommunityId == viewModel.Id))
        //    {
        //        ModelState.AddModelError("", "A community with this name already exists!");
        //        ViewData["SUBAREA_NAMES"] = SubAreas;
        //        return View(viewModel);
        //    }
        //    var community = _adminDatabaseContext.Communities.First(c => c.CommunityId == viewModel.Id);
        //    community.SubAreaId = viewModel.SubAreaId;
        //    community.SubArea = _adminDatabaseContext.SubAreas.First(s => s.SubAreaId == viewModel.SubAreaId);
        //    _adminDatabaseContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var community = _adminDatabaseContext.Communities.Include(c => c.SubArea).First(c => c.Id == id);
            return View(new CommunityViewModel
            {
                Id = id,
                Name = community.Name,
                SubArea = community.SubArea.Name
            });
        }

        [HttpPost]
        public IActionResult Delete(SubAreaViewModel subAreaViewModel)
        {
            var community = _adminDatabaseContext.Communities.First(c => c.Id == subAreaViewModel.Id);
            _adminDatabaseContext.Communities.Remove(community);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateAssociation(Guid id)
        {
            ViewData["MEMBER_NAMES"] = new SelectList(Tenants(id), "Value", "Text");
            return View();
        }

        private IEnumerable<SelectListItem> Tenants(Guid communityId) =>
            _adminDatabaseContext.Communities.Include(c => c.Blocks).ThenInclude(b => b.Apartments)
                .ThenInclude(f => f.Tenants).AsNoTracking()
                .First(c => c.Id == communityId).Blocks.SelectMany(b => b.Apartments).SelectMany(f => f.Tenants)
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.FirstName + " " + m.LastName
                }).ToList();
    }
}