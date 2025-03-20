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
        public async Task<IActionResult> Index(
      string sortOrder,
      string currentFilter,
      string searchString,
      int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";




            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var medicalconditions = _context.MedicalConditions
               .Include(a => a.ElderlyResident)
               .AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                medicalconditions = medicalconditions.Where(a => a.ElderlyResident.FirstName.Contains(searchString));


            }


          

            switch (sortOrder)
            {
                case "name_desc":
                    medicalconditions = medicalconditions.OrderByDescending(s => s.ElderlyResident.FirstName);
                    break;
                case "Date":
                    medicalconditions = medicalconditions.OrderBy(s => s.ElderlyResident.FirstName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<MedicalCondition>.CreateAsync(medicalconditions.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: MedicalConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalConditions == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalConditions
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
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName");
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
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", medicalCondition.ResidentID);
            return View(medicalCondition);
        }

        // GET: MedicalConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalConditions == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalConditions.FindAsync(id);
            if (medicalCondition == null)
            {
                return NotFound();
            }
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", medicalCondition.ResidentID);
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
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", medicalCondition.ResidentID);
            return View(medicalCondition);
        }

        // GET: MedicalConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalConditions == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalConditions
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
            if (_context.MedicalConditions == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.MedicalConditions'  is null.");
            }
            var medicalCondition = await _context.MedicalConditions.FindAsync(id);
            if (medicalCondition != null)
            {
                _context.MedicalConditions.Remove(medicalCondition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalConditionExists(int id)
        {
          return (_context.MedicalConditions?.Any(e => e.ConditionID == id)).GetValueOrDefault();
        }
    }
}
