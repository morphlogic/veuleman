#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeulemanTrainingPlatform.Data;
using VeulemanTrainingPlatform.Models;

namespace VeulemanTrainingPlatform.Controllers
{
    public class FinalPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinalPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FinalPage
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinalPage.ToListAsync());
        }

        // GET: FinalPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalPage = await _context.FinalPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finalPage == null)
            {
                return NotFound();
            }

            return View(finalPage);
        }

        public async Task<IActionResult> Audit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalPage = await _context.FinalPage.FirstOrDefaultAsync(m => m.Id == id);
            
            if (finalPage == null)
            {
                return NotFound();
            }

            return View(finalPage);
        }

        // GET: FinalPage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinalPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Content")] FinalPage finalPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finalPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(finalPage);
        }

        // GET: FinalPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalPage = await _context.FinalPage.FindAsync(id);
            if (finalPage == null)
            {
                return NotFound();
            }
            return View(finalPage);
        }

        // POST: FinalPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Content")] FinalPage finalPage)
        {
            if (id != finalPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finalPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinalPageExists(finalPage.Id))
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
            return View(finalPage);
        }

        // GET: FinalPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalPage = await _context.FinalPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finalPage == null)
            {
                return NotFound();
            }

            return View(finalPage);
        }

        // POST: FinalPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finalPage = await _context.FinalPage.FindAsync(id);
            _context.FinalPage.Remove(finalPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinalPageExists(int id)
        {
            return _context.FinalPage.Any(e => e.Id == id);
        }
    }
}
