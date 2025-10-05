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
    [Authorize(Roles = "Doctor, Caregiver, Manager, Admin")] // Only authenticated users can access 
    public class MedicalRecordsController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public MedicalRecordsController(EverCareCommunityContext context)
        {
            _context = context; 
        }

        // GET: MedicalRecords
        public async Task<IActionResult> Index(
            string sortOrder, // Determines sort order (e.g., name ascending or descending)
            string currentFilter, // Holds the search string from previous requests
            string searchString, // New search input from user
            int? pageNumber) // Page number for pagination
        {
            ViewData["CurrentSort"] = sortOrder; // Pass sort order to the view
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

            // Get all medical records and include related Doctor and ElderlyResident data
            var medicalrecords = _context.MedicalRecords
                .Include(a => a.Doctor)
                .Include(a => a.ElderlyResident)
                .AsNoTracking(); 

            // Filter based on search string
            if (!string.IsNullOrEmpty(searchString))
            {
                medicalrecords = medicalrecords.Where(a => a.ElderlyResident.FirstName.Contains(searchString));
            }

           
            switch (sortOrder)
            {
                case "name_desc":
                    medicalrecords = medicalrecords.OrderByDescending(s => s.ElderlyResident.FirstName);
                    break;
                case "Date": // Not used but kept for future sorting
                    medicalrecords = medicalrecords.OrderBy(s => s.ElderlyResident.FirstName);
                    break;
            }

            int pageSize = 5; // Number of records per page
            return View(await PaginatedList<MedicalRecord>.CreateAsync(medicalrecords.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: MedicalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalRecords == null)
            {
                return NotFound(); // If no ID is provided or DB context is null
            }

            // Find record by ID and include related data
            var medicalRecord = await _context.MedicalRecords
                .Include(m => m.Doctor)
                .Include(m => m.ElderlyResident)
                .FirstOrDefaultAsync(m => m.RecordID == id);

            if (medicalRecord == null)
            {
                return NotFound(); // If record not found
            }

            return View(medicalRecord);
        }

        // GET: MedicalRecords/Create
        public IActionResult Create()
        {
            // Load dropdowns for doctors and residents
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName");
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName");
            return View();
        }

        // POST: MedicalRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public async Task<IActionResult> Create([Bind("RecordID,ResidentID,DoctorID,Diagnosis,Prescription,DateReported")] MedicalRecord medicalRecord)
        {
            if (!ModelState.IsValid) // If the model is valid, save to DB
            {
                _context.Add(medicalRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If model is invalid, reload dropdowns and return view
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", medicalRecord.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", medicalRecord.ResidentID);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalRecords == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            // Load dropdowns with selected values
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", medicalRecord.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", medicalRecord.ResidentID);
            return View(medicalRecord);
        }

        // POST: MedicalRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,ResidentID,DoctorID,Diagnosis,Prescription,DateReported")] MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.RecordID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalRecord); // Update the record
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalRecordExists(medicalRecord.RecordID))
                    {
                        return NotFound(); // If record no longer exists
                    }
                    else
                    {
                        throw; // Re-throw the exception if unknown issue
                    }
                }
                return RedirectToAction(nameof(Index)); // Return to list after update
            }

            // Reload dropdowns and return view on validation error
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", medicalRecord.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResidents, "ResidentID", "FirstName", medicalRecord.ResidentID);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalRecords == null)
            {
                return NotFound();
            }

            // Find record with related data
            var medicalRecord = await _context.MedicalRecords
                .Include(m => m.Doctor)
                .Include(m => m.ElderlyResident)
                .FirstOrDefaultAsync(m => m.RecordID == id);

            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord); // Show confirmation view
        }

        // POST: MedicalRecords/Delete/5
        [HttpPost, ActionName("Delete")] // Custom action name to match route
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalRecords == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.MedicalRecords' is null.");
            }

            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecord != null)
            {
                _context.MedicalRecords.Remove(medicalRecord); // Remove from database
            }

            await _context.SaveChangesAsync(); // Commit changes
            return RedirectToAction(nameof(Index)); // Return to list
        }

        // Helper method to check if a record exists
        private bool MedicalRecordExists(int id)
        {
            return (_context.MedicalRecords?.Any(e => e.RecordID == id)).GetValueOrDefault();
        }
    }
}
