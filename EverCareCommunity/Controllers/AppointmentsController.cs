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
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public AppointmentsController(EverCareCommunityContext context)
        {
            _context = context;
        }

        // GET: Appointments
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

            var appointments = _context.Appointments
                .Include(a => a.Doctor)  
                .Include(a => a.ElderlyResident) 
                .AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                appointments = appointments.Where(a => a.ElderlyResident.FirstName.Contains(searchString)
                                                    || a.Doctor.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    appointments = appointments.OrderByDescending(a => a.ElderlyResident.FirstName);
                    break;
                default:
                    appointments = appointments.OrderBy(a => a.ElderlyResident.FirstName);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Appointment>.CreateAsync(appointments, pageNumber ?? 1, pageSize));
        }
    

    // GET: Appointments/Details/5
    public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.ElderlyResident)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName");
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentID,ResidentID,DoctorID,Status,DateTime")] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", appointment.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", appointment.ResidentID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", appointment.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", appointment.ResidentID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentID,ResidentID,DoctorID,Status,DateTime")] Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentID))
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
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", appointment.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", appointment.ResidentID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.ElderlyResident)
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.Appointments'  is null.");
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
          return (_context.Appointments?.Any(e => e.AppointmentID == id)).GetValueOrDefault();
        }
    }
}
