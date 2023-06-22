using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppNarutoDB.Models;

namespace WebAppNarutoDB.Controllers
{
    public class JutsusController : Controller
    {
        private readonly NarutoDbContext _context;

        public JutsusController(NarutoDbContext context)
        {
            _context = context;
        }

        // GET: Jutsus
        public async Task<IActionResult> Index()
        {
              return _context.Jutsus != null ? 
                          View(await _context.Jutsus.ToListAsync()) :
                          Problem("Entity set 'NarutoDbContext.Jutsus'  is null.");
        }

        // GET: Jutsus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jutsus == null)
            {
                return NotFound();
            }

            var jutsu = await _context.Jutsus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jutsu == null)
            {
                return NotFound();
            }

            return View(jutsu);
        }

        // GET: Jutsus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jutsus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JutsuName")] Jutsu jutsu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jutsu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jutsu);
        }

        // GET: Jutsus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jutsus == null)
            {
                return NotFound();
            }

            var jutsu = await _context.Jutsus.FindAsync(id);
            if (jutsu == null)
            {
                return NotFound();
            }
            return View(jutsu);
        }

        // POST: Jutsus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JutsuName")] Jutsu jutsu)
        {
            if (id != jutsu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jutsu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JutsuExists(jutsu.Id))
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
            return View(jutsu);
        }

        // GET: Jutsus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jutsus == null)
            {
                return NotFound();
            }

            var jutsu = await _context.Jutsus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jutsu == null)
            {
                return NotFound();
            }

            return View(jutsu);
        }

        // POST: Jutsus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jutsus == null)
            {
                return Problem("Entity set 'NarutoDbContext.Jutsus'  is null.");
            }
            var jutsu = await _context.Jutsus.FindAsync(id);
            if (jutsu != null)
            {
                _context.Jutsus.Remove(jutsu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JutsuExists(int id)
        {
          return (_context.Jutsus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
