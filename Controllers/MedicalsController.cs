using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HostelManagementSystem.Models;

namespace HostelManagementSystem.Controllers
{
    public class MedicalsController : Controller
    {
        private readonly HmsContext _context;

        public MedicalsController(HmsContext context)
        {
            _context = context;
        }

        // GET: Medicals
        public async Task<IActionResult> Index()
        {
            var hmsContext = _context.Medicals.Include(m => m.Student);
            return View(await hmsContext.ToListAsync());
        }

        // GET: Medicals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical = await _context.Medicals
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.MedicalId == id);
            if (medical == null)
            {
                return NotFound();
            }

            return View(medical);
        }

        // GET: Medicals/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: Medicals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalId,StudentId,Illness,Date,Treatment")] Medical medical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medical);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", medical.StudentId);
            return View(medical);
        }

        // GET: Medicals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical = await _context.Medicals.FindAsync(id);
            if (medical == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", medical.StudentId);
            return View(medical);
        }

        // POST: Medicals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalId,StudentId,Illness,Date,Treatment")] Medical medical)
        {
            if (id != medical.MedicalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalExists(medical.MedicalId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", medical.StudentId);
            return View(medical);
        }

        // GET: Medicals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical = await _context.Medicals
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.MedicalId == id);
            if (medical == null)
            {
                return NotFound();
            }

            return View(medical);
        }

        // POST: Medicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medical = await _context.Medicals.FindAsync(id);
            if (medical != null)
            {
                _context.Medicals.Remove(medical);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalExists(int id)
        {
            return _context.Medicals.Any(e => e.MedicalId == id);
        }
    }
}
