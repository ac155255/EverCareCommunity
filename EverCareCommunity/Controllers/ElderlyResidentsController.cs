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
    public class ElderlyResidentsController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public ElderlyResidentsController(EverCareCommunityContext context)
        {
            _context = context;
        }

        // GET: ElderlyResidents
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var residents = _context.ElderlyResidents
     .Select(s => new ElderlyResident
     {
         ResidentID = s.ResidentID,
         FirstName = s.FirstName,
         LastName = s.LastName,
         Email = s.Email,
         PhoneNumber = s.PhoneNumber,
         Gender = s.Gender,
         Address = s.Address,
         DateOfBirth = s.DateOfBirth
     });
            if (!String.IsNullOrEmpty(searchString))
            {
                residents = residents.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    residents = residents.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    residents = residents.OrderBy(s => s.DateOfBirth);
                    break;
                case "date_desc":
                    residents = residents.OrderByDescending(s => s.DateOfBirth);
                    break;
                default:
                    residents = residents.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<ElderlyResident>.CreateAsync(residents.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: ElderlyResidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ElderlyResidents == null)
            {
                return NotFound();
            }

            var elderlyResident = await _context.ElderlyResidents
                .FirstOrDefaultAsync(m => m.ResidentID == id);
            if (elderlyResident == null)
            {
                return NotFound();
            }

            return View(elderlyResident);
        }

        // GET: ElderlyResidents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ElderlyResidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResidentID,FirstName,LastName,Email,PhoneNumber,Gender,DateOfBirth,Address")] ElderlyResident elderlyResident)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(elderlyResident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(elderlyResident);
        }

        // GET: ElderlyResidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ElderlyResidents == null)
            {
                return NotFound();
            }

            var elderlyResident = await _context.ElderlyResidents.FindAsync(id);
            if (elderlyResident == null)
            {
                return NotFound();
            }
            return View(elderlyResident);
        }

        // POST: ElderlyResidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResidentID,FirstName,LastName,Email,PhoneNumber,Gender,DateOfBirth,Address")] ElderlyResident elderlyResident)
        {
            if (id != elderlyResident.ResidentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(elderlyResident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElderlyResidentExists(elderlyResident.ResidentID))
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
            return View(elderlyResident);
        }

        // GET: ElderlyResidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ElderlyResidents == null)
            {
                return NotFound();
            }

            var elderlyResident = await _context.ElderlyResidents
                .FirstOrDefaultAsync(m => m.ResidentID == id);
            if (elderlyResident == null)
            {
                return NotFound();
            }

            return View(elderlyResident);
        }

        // POST: ElderlyResidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ElderlyResidents == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.ElderlyResidents'  is null.");
            }
            var elderlyResident = await _context.ElderlyResidents.FindAsync(id);
            if (elderlyResident != null)
            {
                _context.ElderlyResidents.Remove(elderlyResident);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElderlyResidentExists(int id)
        {
          return (_context.ElderlyResidents?.Any(e => e.ResidentID == id)).GetValueOrDefault();
        }
    }
}
