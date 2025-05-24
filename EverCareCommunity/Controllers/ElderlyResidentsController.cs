using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EverCareCommunity.Data;
using EverCareCommunity.Models;
using System.ComponentModel.DataAnnotations;

namespace EverCareCommunity.Controllers
{
    [Authorize(Roles = "Caregiver, Manager, Admin, Doctor")]
    public class ElderlyResidentsController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public ElderlyResidentsController(EverCareCommunityContext context)
        {
            _context = context;
        }

        // GET: ElderlyResidents
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
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

            var residents = _context.ElderlyResidents.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                residents = residents.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            residents = sortOrder switch
            {
                "name_desc" => residents.OrderByDescending(s => s.FirstName),
                "Date" => residents.OrderBy(s => s.DateOfBirth),
                "date_desc" => residents.OrderByDescending(s => s.DateOfBirth),
                _ => residents.OrderBy(s => s.FirstName),
            };

            int pageSize = 5;
            return View(await PaginatedList<ElderlyResident>.CreateAsync(residents.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: ElderlyResidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var resident = await _context.ElderlyResidents.FindAsync(id);
            if (resident == null) return NotFound();

            return View(resident);
        }

        // GET: ElderlyResidents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ElderlyResidents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResidentID,FirstName,LastName,Email,PhoneNumber,Gender,DateOfBirth,Address")] ElderlyResident resident)
        {
            if (resident.DateOfBirth == null || CalculateAge(resident.DateOfBirth.Value) < 40)
            {
                ModelState.AddModelError("DateOfBirth", "Resident must be at least 40 years old.");
            }

            if (!ModelState.IsValid)
            {
                _context.Add(resident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resident);
        }

        // GET: ElderlyResidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var resident = await _context.ElderlyResidents.FindAsync(id);
            if (resident == null) return NotFound();

            return View(resident);
        }

        // POST: ElderlyResidents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResidentID,FirstName,LastName,Email,PhoneNumber,Gender,DateOfBirth,Address")] ElderlyResident resident)
        {
            if (id != resident.ResidentID) return NotFound();

            if (resident.DateOfBirth == null || CalculateAge(resident.DateOfBirth.Value) < 40)
            {
                ModelState.AddModelError("DateOfBirth", "Resident must be at least 40 years old.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ElderlyResidents.Any(e => e.ResidentID == id))
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
            return View(resident);
        }

        // GET: ElderlyResidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var resident = await _context.ElderlyResidents.FindAsync(id);
            if (resident == null) return NotFound();

            return View(resident);
        }

        // POST: ElderlyResidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resident = await _context.ElderlyResidents.FindAsync(id);
            if (resident != null)
            {
                _context.ElderlyResidents.Remove(resident);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private int CalculateAge(DateTime dob)
        {
            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
        }
    }
}