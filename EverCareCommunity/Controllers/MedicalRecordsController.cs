﻿using System;
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
    public class MedicalRecordsController : Controller
    {
        private readonly EverCareCommunityContext _context;

        public MedicalRecordsController(EverCareCommunityContext context)
        {
            _context = context;
        }

        // GET: MedicalRecords
        public async Task<IActionResult> Index()
        {
            var everCareCommunityContext = _context.MedicalRecord.Include(m => m.Doctor).Include(m => m.ElderlyResident);
            return View(await everCareCommunityContext.ToListAsync());
        }

        // GET: MedicalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalRecord == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord
                .Include(m => m.Doctor)
                .Include(m => m.ElderlyResident)
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // GET: MedicalRecords/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "Email");
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "Email");
            return View();
        }

        // POST: MedicalRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,ResidentID,DoctorID,Diagnosis,Prescription,DateReported")] MedicalRecord medicalRecord)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(medicalRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "Email", medicalRecord.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "Email", medicalRecord.ResidentID);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalRecord == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord.FindAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "Email", medicalRecord.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "Email", medicalRecord.ResidentID);
            return View(medicalRecord);
        }

        // POST: MedicalRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(medicalRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalRecordExists(medicalRecord.RecordID))
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
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "Email", medicalRecord.DoctorID);
            ViewData["ResidentID"] = new SelectList(_context.ElderlyResident, "ResidentID", "Email", medicalRecord.ResidentID);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalRecord == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord
                .Include(m => m.Doctor)
                .Include(m => m.ElderlyResident)
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // POST: MedicalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalRecord == null)
            {
                return Problem("Entity set 'EverCareCommunityContext.MedicalRecord'  is null.");
            }
            var medicalRecord = await _context.MedicalRecord.FindAsync(id);
            if (medicalRecord != null)
            {
                _context.MedicalRecord.Remove(medicalRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalRecordExists(int id)
        {
          return (_context.MedicalRecord?.Any(e => e.RecordID == id)).GetValueOrDefault();
        }
    }
}
