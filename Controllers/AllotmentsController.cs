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
    public class AllotmentsController : Controller
    {
        private readonly HmsContext _context;

        public AllotmentsController(HmsContext context)
        {
            _context = context;
        }

        // GET: Allotments
        public async Task<IActionResult> Index()
        {
            var hmsContext = _context.Allotments.Include(a => a.RoomNumberNavigation).Include(a => a.Student);
            return View(await hmsContext.ToListAsync());
        }

        // GET: Allotments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allotment = await _context.Allotments
                .Include(a => a.RoomNumberNavigation)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AllotmentId == id);
            if (allotment == null)
            {
                return NotFound();
            }

            return View(allotment);
        }

        // GET: Allotments/Create
        public IActionResult Create()
        {
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: Allotments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllotmentId,StudentId,RoomNumber,AllotmentDate,ReleaseDate")] Allotment allotment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allotment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber", allotment.RoomNumber);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", allotment.StudentId);
            return View(allotment);
        }

        // GET: Allotments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allotment = await _context.Allotments.FindAsync(id);
            if (allotment == null)
            {
                return NotFound();
            }
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber", allotment.RoomNumber);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", allotment.StudentId);
            return View(allotment);
        }

        // POST: Allotments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllotmentId,StudentId,RoomNumber,AllotmentDate,ReleaseDate")] Allotment allotment)
        {
            if (id != allotment.AllotmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allotment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllotmentExists(allotment.AllotmentId))
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
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber", allotment.RoomNumber);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", allotment.StudentId);
            return View(allotment);
        }

        // GET: Allotments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allotment = await _context.Allotments
                .Include(a => a.RoomNumberNavigation)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AllotmentId == id);
            if (allotment == null)
            {
                return NotFound();
            }

            return View(allotment);
        }

        // POST: Allotments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allotment = await _context.Allotments.FindAsync(id);
            if (allotment != null)
            {
                _context.Allotments.Remove(allotment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllotmentExists(int id)
        {
            return _context.Allotments.Any(e => e.AllotmentId == id);
        }
    }
}
