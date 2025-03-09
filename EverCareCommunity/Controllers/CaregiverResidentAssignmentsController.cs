using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EverCareCommunity.Data;
using EverCareCommunity.Models;

namespace EverCareCommunity.Controllers
{
    public class CaregiverResidentAssignmentsController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public CaregiverResidentAssignmentsController(EverCareCommunityContext context)
        {
            _context = context;
        }

        // GET: CaregiverResidentAssignments
        public async Task<IActionResult> Index()
        {
            var everCareCommunityContext = _context.CaregiverResidentAssignment.Include(c => c.Caregiver).Include(c => c.ElderlyResident);
            return View(await everCareCommunityContext.ToListAsync());
        }

        // GET: CaregiverResidentAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CaregiverResidentAssignment == null)
            {
                return NotFound();
            }

            var caregiverResidentAssignment = await _context.CaregiverResidentAssignment
                .Include(c => c.Caregiver)
                .Include(c => c.ElderlyResident)
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (caregiverResidentAssignment == null)
            {
                return NotFound();
            }

            return View(caregiverResidentAssignment);
        }

        // GET: CaregiverResidentAssignments/Create
        public IActionResult Create()
        {
            ViewData["CaregiverID"] = new SelectList(_context.Caregiver, "CaregiverID", "Qualification");
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "FirstName");
            return View();
        }

        // POST: CaregiverResidentAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentID,CaregiverID,ResidentID,Notes")] CaregiverResidentAssignment caregiverResidentAssignment)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(caregiverResidentAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaregiverID"] = new SelectList(_context.Caregiver, "CaregiverID", "Qualification", caregiverResidentAssignment.CaregiverID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "FirstName", caregiverResidentAssignment.ResidentID);
            return View(caregiverResidentAssignment);
        }

        // GET: CaregiverResidentAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CaregiverResidentAssignment == null)
            {
                return NotFound();
            }

            var caregiverResidentAssignment = await _context.CaregiverResidentAssignment.FindAsync(id);
            if (caregiverResidentAssignment == null)
            {
                return NotFound();
            }
            ViewData["CaregiverID"] = new SelectList(_context.Caregiver, "CaregiverID", "Qualification", caregiverResidentAssignment.CaregiverID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "FirstName", caregiverResidentAssignment.ResidentID);
            return View(caregiverResidentAssignment);
        }

        // POST: CaregiverResidentAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentID,CaregiverID,ResidentID,Notes")] CaregiverResidentAssignment caregiverResidentAssignment)
        {
            if (id != caregiverResidentAssignment.AssignmentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(caregiverResidentAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaregiverResidentAssignmentExists(caregiverResidentAssignment.AssignmentID))
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
            ViewData["CaregiverID"] = new SelectList(_context.Caregiver, "CaregiverID", "Qualification", caregiverResidentAssignment.CaregiverID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "FirstName", caregiverResidentAssignment.ResidentID);
            return View(caregiverResidentAssignment);
        }

        // GET: CaregiverResidentAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CaregiverResidentAssignment == null)
            {
                return NotFound();
            }

            var caregiverResidentAssignment = await _context.CaregiverResidentAssignment
                .Include(c => c.Caregiver)
                .Include(c => c.ElderlyResident)
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (caregiverResidentAssignment == null)
            {
                return NotFound();
            }

            return View(caregiverResidentAssignment);
        }

        // POST: CaregiverResidentAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CaregiverResidentAssignment == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.CaregiverResidentAssignment'  is null.");
            }
            var caregiverResidentAssignment = await _context.CaregiverResidentAssignment.FindAsync(id);
            if (caregiverResidentAssignment != null)
            {
                _context.CaregiverResidentAssignment.Remove(caregiverResidentAssignment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaregiverResidentAssignmentExists(int id)
        {
          return (_context.CaregiverResidentAssignment?.Any(e => e.AssignmentID == id)).GetValueOrDefault();
        }
    }
}
