using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EverCareCommunity.Data;
using EverCareCommunity.Models;
using Microsoft.AspNetCore.Authorization;

namespace EverCareCommunity.Controllers
{
    [Authorize(Roles = "Caregiver, Manager, Admin, Doctor")]
    public class EmergencyContactsController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public EmergencyContactsController(EverCareCommunityContext context)
        {
            _context = context;
        }

        // GET: EmergencyContacts
        public async Task<IActionResult> Index(string searchString, string sortOrder, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var emergencycontacts = _context.EmergencyContacts
        
                .Include(a => a.ElderlyResident)
                .Include(a => a.Address)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                emergencycontacts = emergencycontacts.Where(a => a.ElderlyResident.FirstName.Contains(searchString));
                                                    
            }

            switch (sortOrder)
            {
                case "name_desc":
                    emergencycontacts = emergencycontacts.OrderByDescending(a => a.ElderlyResident.FirstName);
                    break;
                default:
                    emergencycontacts = emergencycontacts.OrderBy(a => a.ElderlyResident.FirstName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<EmergencyContact>.CreateAsync(emergencycontacts, pageNumber ?? 1, pageSize));
        }

        // GET: EmergencyContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmergencyContacts == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContacts
                .Include(e => e.Address)
                .Include(e => e.ElderlyResident)
                .FirstOrDefaultAsync(m => m.EmergencyContactID == id);
            if (emergencyContact == null)
            {
                return NotFound();
            }

            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "City");
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName");
            return View();
        }

        // POST: EmergencyContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmergencyContactID,ResidentID,AddressID,FirstName,LastName,Relationship,PhoneNumber")] EmergencyContact emergencyContact)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(emergencyContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "City", emergencyContact.AddressID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", emergencyContact.ResidentID);
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmergencyContacts == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContacts.FindAsync(id);
            if (emergencyContact == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "City", emergencyContact.AddressID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", emergencyContact.ResidentID);
            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmergencyContactID,ResidentID,AddressID,FirstName,LastName,Relationship,PhoneNumber")] EmergencyContact emergencyContact)
        {
            if (id != emergencyContact.EmergencyContactID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergencyContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergencyContactExists(emergencyContact.EmergencyContactID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "City", emergencyContact.AddressID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", emergencyContact.ResidentID);
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmergencyContacts == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContacts
                .Include(e => e.Address)
                .Include(e => e.ElderlyResident)
                .FirstOrDefaultAsync(m => m.EmergencyContactID == id);
            if (emergencyContact == null)
            {
                return NotFound();
            }

            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmergencyContacts == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.EmergencyContacts'  is null.");
            }
            var emergencyContact = await _context.EmergencyContacts.FindAsync(id);
            if (emergencyContact != null)
            {
                _context.EmergencyContacts.Remove(emergencyContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmergencyContactExists(int id)
        {
          return (_context.EmergencyContacts?.Any(e => e.EmergencyContactID == id)).GetValueOrDefault();
        }
    }
}
