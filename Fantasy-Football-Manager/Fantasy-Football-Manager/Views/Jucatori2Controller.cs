using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fantasy_Football_Manager.Data;
using Fantasy_Football_Manager.Models;

namespace Fantasy_Football_Manager.Views
{
    public class Jucatori2Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IJucatorRepo _jucatorRepo;
        public Jucatori2Controller(ApplicationDbContext context, IJucatorRepo jucatorRepo)
        {
            _jucatorRepo = jucatorRepo;
            _context = context;
        }

        // GET: Jucatori2
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jucatori.Include(j => j.StatisticiJucator);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jucatori2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucatori
                .Include(j => j.StatisticiJucator)
                .FirstOrDefaultAsync(m => m.JucatorId == id);
            if (jucator == null)
            {
                return NotFound();
            }

            return View(jucator);
        }

        // GET: Jucatori2/Create
        public IActionResult Create()
        {
            //ViewData["StatisticiJucatorId"] = new SelectList(_context.StatisticiJucatori, "StatisticiJucatorId", "StatisticiJucatorId");
            return View();
        }

        // POST: Jucatori2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JucatorId,NumeJucator,PrenumeJucator,PozitieJucator,EchipaFotbal")] Jucator jucator)
        {
            if (ModelState.IsValid)
            {
                StatisticiJucator statisticiJucator = new StatisticiJucator();
                statisticiJucator.NrAssists = 0;
                statisticiJucator.NrCleansheets = 0;
                statisticiJucator.NrGoluri = 0;
                statisticiJucator.NrTotalPuncte = 0;
                _jucatorRepo.AddPlayer(jucator, statisticiJucator);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["StatisticiJucatorId"] = new SelectList(_context.StatisticiJucatori, "StatisticiJucatorId", "StatisticiJucatorId", jucator.StatisticiJucatorId);
            return View(jucator);
        }

        // GET: Jucatori2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucatori.FindAsync(id);
            if (jucator == null)
            {
                return NotFound();
            }
            ViewData["StatisticiJucatorId"] = new SelectList(_context.StatisticiJucatori, "StatisticiJucatorId", "StatisticiJucatorId", jucator.StatisticiJucatorId);
            return View(jucator);
        }

        // POST: Jucatori2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JucatorId,NumeJucator,PrenumeJucator,PozitieJucator,EchipaFotbal,StatisticiJucatorId")] Jucator jucator)
        {
            if (id != jucator.JucatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jucator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JucatorExists(jucator.JucatorId))
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
            ViewData["StatisticiJucatorId"] = new SelectList(_context.StatisticiJucatori, "StatisticiJucatorId", "StatisticiJucatorId", jucator.StatisticiJucatorId);
            return View(jucator);
        }

        // GET: Jucatori2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucatori
                .Include(j => j.StatisticiJucator)
                .FirstOrDefaultAsync(m => m.JucatorId == id);
            if (jucator == null)
            {
                return NotFound();
            }

            return View(jucator);
        }

        // POST: Jucatori2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Jucator jucator = _context.Jucatori.Find(id);
            _jucatorRepo.DeletePlayer(jucator);
            return RedirectToAction(nameof(Index));
        }

        private bool JucatorExists(int id)
        {
            return _context.Jucatori.Any(e => e.JucatorId == id);
        }
    }
}
