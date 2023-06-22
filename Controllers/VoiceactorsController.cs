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
    public class VoiceactorsController : Controller
    {
        private readonly NarutoDbContext _context;

        public VoiceactorsController(NarutoDbContext context)
        {
            _context = context;
        }

        // GET: Voiceactors
        public async Task<IActionResult> Index()
        {
              return _context.Voiceactors != null ? 
                          View(await _context.Voiceactors.ToListAsync()) :
                          Problem("Entity set 'NarutoDbContext.Voiceactors'  is null.");
        }

        // GET: Voiceactors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voiceactors == null)
            {
                return NotFound();
            }

            var voiceactor = await _context.Voiceactors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiceactor == null)
            {
                return NotFound();
            }

            return View(voiceactor);
        }

        // GET: Voiceactors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voiceactors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActorName,LanguageVersion")] Voiceactor voiceactor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voiceactor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voiceactor);
        }

        // GET: Voiceactors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voiceactors == null)
            {
                return NotFound();
            }

            var voiceactor = await _context.Voiceactors.FindAsync(id);
            if (voiceactor == null)
            {
                return NotFound();
            }
            return View(voiceactor);
        }

        // POST: Voiceactors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActorName,LanguageVersion")] Voiceactor voiceactor)
        {
            if (id != voiceactor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voiceactor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoiceactorExists(voiceactor.Id))
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
            return View(voiceactor);
        }

        // GET: Voiceactors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voiceactors == null)
            {
                return NotFound();
            }

            var voiceactor = await _context.Voiceactors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiceactor == null)
            {
                return NotFound();
            }

            return View(voiceactor);
        }

        // POST: Voiceactors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voiceactors == null)
            {
                return Problem("Entity set 'NarutoDbContext.Voiceactors'  is null.");
            }
            var voiceactor = await _context.Voiceactors.FindAsync(id);
            if (voiceactor != null)
            {
                _context.Voiceactors.Remove(voiceactor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoiceactorExists(int id)
        {
          return (_context.Voiceactors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
