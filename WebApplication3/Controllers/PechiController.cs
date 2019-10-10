using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Models.Entities;

namespace WebApplication3.Controllers
{
    public class PechiController : Controller
    {
        private readonly DcContext _context;

        public PechiController(DcContext context)
        {
            _context = context;
        }

        // GET: Pechi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pechi.ToListAsync());
        }

        // GET: Pechi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pechi = await _context.Pechi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pechi == null)
            {
                return NotFound();
            }

            return View(pechi);
        }

        // GET: Pechi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pechi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NFurm")] Pechi pechi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pechi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pechi);
        }

        // GET: Pechi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pechi = await _context.Pechi.FindAsync(id);
            if (pechi == null)
            {
                return NotFound();
            }
            return View(pechi);
        }

        // POST: Pechi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NFurm")] Pechi pechi)
        {
            if (id != pechi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pechi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PechiExists(pechi.Id))
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
            return View(pechi);
        }

        // GET: Pechi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pechi = await _context.Pechi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pechi == null)
            {
                return NotFound();
            }

            return View(pechi);
        }

        // POST: Pechi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pechi = await _context.Pechi.FindAsync(id);
            _context.Pechi.Remove(pechi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PechiExists(int id)
        {
            return _context.Pechi.Any(e => e.Id == id);
        }
    }
}
