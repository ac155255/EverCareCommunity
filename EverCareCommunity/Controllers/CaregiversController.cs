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
    public class CaregiversController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public CaregiversController(EverCareCommunityContext context)
        {
            _context = context;
        }

        // GET: Caregivers
        public async Task<IActionResult> Index()
        {
              return _context.Caregivers != null ? 
                          View(await _context.Caregivers.ToListAsync()) :
                          Problem("Entity set 'EverCareCommunityContext.Caregivers'  is null.");
        }

        // GET: Caregivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Caregivers == null)
            {
                return NotFound();
            }

            var caregiver = await _context.Caregivers
                .FirstOrDefaultAsync(m => m.CaregiverID == id);
            if (caregiver == null)
            {
                return NotFound();
            }

            return View(caregiver);
        }

        // GET: Caregivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caregivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaregiverID,FirstName,LastName,QualificationType,Email,Phone,Experience,Availability")] Caregiver caregiver)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(caregiver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caregiver);
        }

        // GET: Caregivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Caregivers == null)
            {
                return NotFound();
            }

            var caregiver = await _context.Caregivers.FindAsync(id);
            if (caregiver == null)
            {
                return NotFound();
            }
            return View(caregiver);
        }

        // POST: Caregivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaregiverID,FirstName,LastName,QualificationType,Email,Phone,Experience,Availability")] Caregiver caregiver)
        {
            if (id != caregiver.CaregiverID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(caregiver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaregiverExists(caregiver.CaregiverID))
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
            return View(caregiver);
        }

        // GET: Caregivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Caregivers == null)
            {
                return NotFound();
            }

            var caregiver = await _context.Caregivers
                .FirstOrDefaultAsync(m => m.CaregiverID == id);
            if (caregiver == null)
            {
                return NotFound();
            }

            return View(caregiver);
        }

        // POST: Caregivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Caregivers == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.Caregivers'  is null.");
            }
            var caregiver = await _context.Caregivers.FindAsync(id);
            if (caregiver != null)
            {
                _context.Caregivers.Remove(caregiver);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaregiverExists(int id)
        {
          return (_context.Caregivers?.Any(e => e.CaregiverID == id)).GetValueOrDefault();
        }
    }
}
