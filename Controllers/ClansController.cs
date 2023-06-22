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
    public class ClansController : Controller
    {
        private readonly NarutoDbContext _context;

        public ClansController(NarutoDbContext context)
        {
            _context = context;
        }

        // GET: Clans
        public async Task<IActionResult> Index()
        {
              return _context.Clans != null ? 
                          View(await _context.Clans.ToListAsync()) :
                          Problem("Entity set 'NarutoDbContext.Clans'  is null.");
        }

        // GET: Clans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clans == null)
            {
                return NotFound();
            }

            var clan = await _context.Clans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clan == null)
            {
                return NotFound();
            }

            return View(clan);
        }

        // GET: Clans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClanName")] Clan clan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clan);
        }

        // GET: Clans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clans == null)
            {
                return NotFound();
            }

            var clan = await _context.Clans.FindAsync(id);
            if (clan == null)
            {
                return NotFound();
            }
            return View(clan);
        }

        // POST: Clans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClanName")] Clan clan)
        {
            if (id != clan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClanExists(clan.Id))
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
            return View(clan);
        }

        // GET: Clans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clans == null)
            {
                return NotFound();
            }

            var clan = await _context.Clans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clan == null)
            {
                return NotFound();
            }

            return View(clan);
        }

        // POST: Clans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clans == null)
            {
                return Problem("Entity set 'NarutoDbContext.Clans'  is null.");
            }
            var clan = await _context.Clans.FindAsync(id);
            if (clan != null)
            {
                _context.Clans.Remove(clan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClanExists(int id)
        {
          return (_context.Clans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
