using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommunityMgmtPortal.Data;
using CommunityMgmtPortal.Models;

namespace CommunityMgmtPortal.Controllers
{
    public class CommunitiesController : Controller
    {
        private readonly CommunityMgmtDbContext _context;

        public CommunitiesController(CommunityMgmtDbContext context)
        {
            _context = context;
        }

        // GET: Communities
        public async Task<IActionResult> Index()
        {
            var communityMgmtDbContext = _context.Community.Include(c => c.CreatedByNavigation).Include(c => c.Location).Include(c => c.SubArea).Include(c => c.UpdatedByNavigation);
            return View(await communityMgmtDbContext.ToListAsync());
        }

        // GET: Communities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.Location)
                .Include(c => c.SubArea)
                .Include(c => c.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // GET: Communities/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.User, "Id", "UserName");
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "AddressLine1");
            ViewData["SubAreaId"] = new SelectList(_context.SubArea, "Id", "Name");
            ViewData["UpdatedBy"] = new SelectList(_context.User, "Id", "UserName");
            return View();
        }

        // POST: Communities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,Created,Updated,UpdatedBy,Active,Tags,Comments,Name,LocationId,SubAreaId")] Community community)
        {
            if (ModelState.IsValid)
            {
                community.Id = Guid.NewGuid();
                _context.Add(community);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.User, "Id", "UserName", community.CreatedBy);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "AddressLine1", community.LocationId);
            ViewData["SubAreaId"] = new SelectList(_context.SubArea, "Id", "Name", community.SubAreaId);
            ViewData["UpdatedBy"] = new SelectList(_context.User, "Id", "UserName", community.UpdatedBy);
            return View(community);
        }

        // GET: Communities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community.FindAsync(id);
            if (community == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.User, "Id", "UserName", community.CreatedBy);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "AddressLine1", community.LocationId);
            ViewData["SubAreaId"] = new SelectList(_context.SubArea, "Id", "Name", community.SubAreaId);
            ViewData["UpdatedBy"] = new SelectList(_context.User, "Id", "UserName", community.UpdatedBy);
            return View(community);
        }

        // POST: Communities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedBy,Created,Updated,UpdatedBy,Active,Tags,Comments,Name,LocationId,SubAreaId")] Community community)
        {
            if (id != community.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(community);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunityExists(community.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.User, "Id", "UserName", community.CreatedBy);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "AddressLine1", community.LocationId);
            ViewData["SubAreaId"] = new SelectList(_context.SubArea, "Id", "Name", community.SubAreaId);
            ViewData["UpdatedBy"] = new SelectList(_context.User, "Id", "UserName", community.UpdatedBy);
            return View(community);
        }

        // GET: Communities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.Location)
                .Include(c => c.SubArea)
                .Include(c => c.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // POST: Communities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var community = await _context.Community.FindAsync(id);
            _context.Community.Remove(community);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityExists(Guid id)
        {
            return _context.Community.Any(e => e.Id == id);
        }
    }
}
