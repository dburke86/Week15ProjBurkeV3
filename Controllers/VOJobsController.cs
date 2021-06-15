using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week15ProjBurkeV2.Data;
using Week15ProjBurkeV2.Models;

namespace Week15ProjBurkeV2.Controllers
{
    public class VOJobsController : Controller
    {
        private readonly VoiceOverDBContext _context;

        public VOJobsController(VoiceOverDBContext context)
        {
            _context = context;
        }

        // GET: VOJobs
        public async Task<IActionResult> Index()
        {
            return View(await _context.VOJobs.ToListAsync());
        }

        // GET: VOJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vOJobs = await _context.VOJobs
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (vOJobs == null)
            {
                return NotFound();
            }

            return View(vOJobs);
        }

        // GET: VOJobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VOJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,ClientId,Description,ClientName,ClientEmail,DueDate")] VOJobs vOJobs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vOJobs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vOJobs);
        }

        // GET: VOJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vOJobs = await _context.VOJobs.FindAsync(id);
            if (vOJobs == null)
            {
                return NotFound();
            }
            return View(vOJobs);
        }

        // POST: VOJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,ClientId,Description,ClientName,ClientEmail,DueDate")] VOJobs vOJobs)
        {
            if (id != vOJobs.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vOJobs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VOJobsExists(vOJobs.ClientId))
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
            return View(vOJobs);
        }

        // GET: VOJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vOJobs = await _context.VOJobs
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (vOJobs == null)
            {
                return NotFound();
            }

            return View(vOJobs);
        }

        // POST: VOJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vOJobs = await _context.VOJobs.FindAsync(id);
            _context.VOJobs.Remove(vOJobs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VOJobsExists(int id)
        {
            return _context.VOJobs.Any(e => e.ClientId == id);
        }
    }
}
