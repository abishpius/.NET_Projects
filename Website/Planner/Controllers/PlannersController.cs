using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlannerWebApp.Data;
using PlannerWebApp.Models;

namespace PlannerWebApp.Controllers
{
    public class PlannersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlannersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planner.ToListAsync());
        }

        // GET: Planner/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // Post: Planner/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Planner.Where(j => j.Task.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Planners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planner == null)
            {
                return NotFound();
            }

            return View(planner);
        }

        // GET: Planners/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Task,Progress")] Planner planner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planner);
        }

        // GET: Planners/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner.FindAsync(id);
            if (planner == null)
            {
                return NotFound();
            }
            return View(planner);
        }

        // POST: Planners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Task,Progress")] Planner planner)
        {
            if (id != planner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlannerExists(planner.Id))
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
            return View(planner);
        }

        // GET: Planners/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planner == null)
            {
                return NotFound();
            }

            return View(planner);
        }

        // POST: Planners/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planner = await _context.Planner.FindAsync(id);
            _context.Planner.Remove(planner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlannerExists(int id)
        {
            return _context.Planner.Any(e => e.Id == id);
        }
    }
}
