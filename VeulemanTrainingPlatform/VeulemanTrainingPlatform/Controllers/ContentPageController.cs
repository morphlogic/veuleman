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
    public class ContentPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentPage
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContentPages.ToListAsync());
        }

        // GET: ContentPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentPage = await _context.ContentPages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentPage == null)
            {
                return NotFound();
            }

            return View(contentPage);
        }

        // GET: ContentPage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Content")] ContentPage contentPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contentPage);
        }

        // GET: ContentPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentPage = await _context.ContentPages.FindAsync(id);
            if (contentPage == null)
            {
                return NotFound();
            }
            return View(contentPage);
        }

        // POST: ContentPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Content")] ContentPage contentPage)
        {
            if (id != contentPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentPageExists(contentPage.Id))
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
            return View(contentPage);
        }

        // GET: ContentPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentPage = await _context.ContentPages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentPage == null)
            {
                return NotFound();
            }

            return View(contentPage);
        }

        // POST: ContentPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentPage = await _context.ContentPages.FindAsync(id);
            _context.ContentPages.Remove(contentPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentPageExists(int id)
        {
            return _context.ContentPages.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Audit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentPage = await _context.ContentPages.FirstOrDefaultAsync(m => m.Id == id);

            if (contentPage == null)
            {
                return NotFound();
            }

            return View(contentPage);
        }

        public async Task<IActionResult> AuditNext(int id)
        {
            var chapter = _context.Chapters.Include("QuizPage").Include("ContentPages").First(c => c.ContentPages.Any(p => p.Id == id));

            var currentContentPage = chapter.ContentPages.Single(c => c.Id == id);

            var nextContentPage = chapter.ContentPages.FirstOrDefault(p => p.Order == currentContentPage.Order + 1);

            if (nextContentPage != null)
            {
                return RedirectToAction("Audit", new { id = nextContentPage.Id });
            }

            return RedirectToAction("Audit", "QuizPage", new { id = chapter.QuizPage.Id });
        }
    }
}
