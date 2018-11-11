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
    public class ContactsController : Controller
    {
        private readonly CommunityMgmtDbContext _context;

        public ContactsController(CommunityMgmtDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var communityMgmtDbContext = _context.Contact.Include(c => c.CreatedByNavigation).Include(c => c.Image).Include(c => c.Location).Include(c => c.UpdatedByNavigation);
            return View(await communityMgmtDbContext.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.Image)
                .Include(c => c.Location)
                .Include(c => c.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.User, "Id", "UserName");
            ViewData["ImageId"] = new SelectList(_context.Image, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "AddressLine1");
            ViewData["UpdatedBy"] = new SelectList(_context.User, "Id", "UserName");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,Created,Updated,UpdatedBy,Active,Tags,Comments,FirstName,MiddleName,LastName,Title,LocationId,ImageId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = Guid.NewGuid();
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.User, "Id", "UserName", contact.CreatedBy);
            ViewData["ImageId"] = new SelectList(_context.Image, "Id", "Id", contact.ImageId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "AddressLine1", contact.LocationId);
            ViewData["UpdatedBy"] = new SelectList(_context.User, "Id", "UserName", contact.UpdatedBy);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.User, "Id", "UserName", contact.CreatedBy);
            ViewData["ImageId"] = new SelectList(_context.Image, "Id", "Id", contact.ImageId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "AddressLine1", contact.LocationId);
            ViewData["UpdatedBy"] = new SelectList(_context.User, "Id", "UserName", contact.UpdatedBy);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedBy,Created,Updated,UpdatedBy,Active,Tags,Comments,FirstName,MiddleName,LastName,Title,LocationId,ImageId")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            ViewData["CreatedBy"] = new SelectList(_context.User, "Id", "UserName", contact.CreatedBy);
            ViewData["ImageId"] = new SelectList(_context.Image, "Id", "Id", contact.ImageId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "AddressLine1", contact.LocationId);
            ViewData["UpdatedBy"] = new SelectList(_context.User, "Id", "UserName", contact.UpdatedBy);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.Image)
                .Include(c => c.Location)
                .Include(c => c.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contact = await _context.Contact.FindAsync(id);
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(Guid id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}
