using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class ShoutsController : Controller
    {
        private readonly WebApplicationDbContext _context;

        public ShoutsController(WebApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shouts
        public async Task<IActionResult> Index()
        {
              return _context.Shout != null ? 
                          View(await _context.Shout.ToListAsync()) :
                          Problem("Entity set 'WebApplicationDbContext.Shout'  is null.");
        }

        public async Task<IActionResult> Wallshout()
        {
            return _context.Shout != null ?
                        View(await _context.Shout.ToListAsync()) :
                        Problem("Entity set 'WebApplicationDbContext.Shout'  is null.");
        }

        // GET: Shouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shout == null)
            {
                return NotFound();
            }

            var shout = await _context.Shout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shout == null)
            {
                return NotFound();
            }

            return View(shout);
        }

        // GET: Shouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShoutEntry,ShoutDate, ShoutName")] Shouts shout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shout);
        }

        // GET: Shouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shout == null)
            {
                return NotFound();
            }

            var shout = await _context.Shout.FindAsync(id);
            if (shout == null)
            {
                return NotFound();
            }
            return View(shout);
        }

        // POST: Shouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShoutEntry, ShoutDate, ShoutName")] Shouts shout)
        {
            if (id != shout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoutExists(shout.Id))
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
            return View(shout);
        }

        // GET: Shouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shout == null)
            {
                return NotFound();
            }

            var shout = await _context.Shout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shout == null)
            {
                return NotFound();
            }

            return View(shout);
        }

        // POST: Shouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shout == null)
            {
                return Problem("Entity set 'WebApplicationDbContext.Shout'  is null.");
            }
            var shout = await _context.Shout.FindAsync(id);
            if (shout != null)
            {
                _context.Shout.Remove(shout);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoutExists(int id)
        {
          return (_context.Shout?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
