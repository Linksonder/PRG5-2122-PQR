using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KleineDemo.Models;

namespace KleineDemo.Controllers
{
    public class SuperpowersController : Controller
    {
        private readonly MijnContext _context;

        public SuperpowersController(MijnContext context)
        {
            _context = context;
        }

        // GET: Superpowers
        public async Task<IActionResult> Index()
        {
            var mijnContext = _context.Superpower.Include(s => s.Hero);
            return View(await mijnContext.ToListAsync());
        }

        // GET: Superpowers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superpower = await _context.Superpower
                .Include(s => s.Hero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superpower == null)
            {
                return NotFound();
            }

            return View(superpower);
        }

        // GET: Superpowers/Create
        public IActionResult Create()
        {
            ViewData["HeroId"] = new SelectList(_context.Heroes, "Id", "Id");
            return View();
        }

        // POST: Superpowers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HeroId")] Superpower superpower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superpower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HeroId"] = new SelectList(_context.Heroes, "Id", "Id", superpower.HeroId);
            return View(superpower);
        }

        // GET: Superpowers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superpower = await _context.Superpower.FindAsync(id);
            if (superpower == null)
            {
                return NotFound();
            }
            ViewData["HeroId"] = new SelectList(_context.Heroes, "Id", "Id", superpower.HeroId);
            return View(superpower);
        }

        // POST: Superpowers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,HeroId")] Superpower superpower)
        {
            if (id != superpower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superpower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperpowerExists(superpower.Id))
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
            ViewData["HeroId"] = new SelectList(_context.Heroes, "Id", "Id", superpower.HeroId);
            return View(superpower);
        }

        // GET: Superpowers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superpower = await _context.Superpower
                .Include(s => s.Hero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superpower == null)
            {
                return NotFound();
            }

            return View(superpower);
        }

        // POST: Superpowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var superpower = await _context.Superpower.FindAsync(id);
            _context.Superpower.Remove(superpower);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperpowerExists(string id)
        {
            return _context.Superpower.Any(e => e.Id == id);
        }
    }
}
