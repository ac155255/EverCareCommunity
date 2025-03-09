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
    public class MedicalConditionsController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public MedicalConditionsController(EverCareCommunityContext context)
        {
            _context = context;
        }

        // GET: MedicalConditions
        public async Task<IActionResult> Index()
        {
            var everCareCommunityContext = _context.MedicalCondition.Include(m => m.ElderlyResident);
            return View(await everCareCommunityContext.ToListAsync());
        }

        // GET: MedicalConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalCondition == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalCondition
                .Include(m => m.ElderlyResident)
                .FirstOrDefaultAsync(m => m.ConditionID == id);
            if (medicalCondition == null)
            {
                return NotFound();
            }

            return View(medicalCondition);
        }

        // GET: MedicalConditions/Create
        public IActionResult Create()
        {
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "Email");
            return View();
        }

        // POST: MedicalConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConditionID,ResidentID,ConditionName,Description")] MedicalCondition medicalCondition)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(medicalCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "Email", medicalCondition.ResidentID);
            return View(medicalCondition);
        }

        // GET: MedicalConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalCondition == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalCondition.FindAsync(id);
            if (medicalCondition == null)
            {
                return NotFound();
            }
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "Email", medicalCondition.ResidentID);
            return View(medicalCondition);
        }

        // POST: MedicalConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConditionID,ResidentID,ConditionName,Description")] MedicalCondition medicalCondition)
        {
            if (id != medicalCondition.ConditionID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalConditionExists(medicalCondition.ConditionID))
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
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "Email", medicalCondition.ResidentID);
            return View(medicalCondition);
        }

        // GET: MedicalConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalCondition == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalCondition
                .Include(m => m.ElderlyResident)
                .FirstOrDefaultAsync(m => m.ConditionID == id);
            if (medicalCondition == null)
            {
                return NotFound();
            }

            return View(medicalCondition);
        }

        // POST: MedicalConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalCondition == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.MedicalCondition'  is null.");
            }
            var medicalCondition = await _context.MedicalCondition.FindAsync(id);
            if (medicalCondition != null)
            {
                _context.MedicalCondition.Remove(medicalCondition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalConditionExists(int id)
        {
          return (_context.MedicalCondition?.Any(e => e.ConditionID == id)).GetValueOrDefault();
        }
    }
}
