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
    public class QuizPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuizPage
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuizPage.ToListAsync());
        }

        // GET: QuizPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizPage = await _context.QuizPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizPage == null)
            {
                return NotFound();
            }

            return View(quizPage);
        }

        public async Task<IActionResult> AuditNext(int id)
        {
            var courses = _context.Courses.Include("Chapters");

            var currentChapter = _context.Chapters.Include("QuizPage").FirstOrDefault(c => c.QuizPage.Id == id);

            var currentCourse = _context.Courses.Include("FinalPage").Include("Chapters").FirstOrDefault(c => c.Chapters.Any(c => c.Id == currentChapter.Id));

            var nextChapter = currentCourse.Chapters.FirstOrDefault(c => c.Order == currentChapter.Order + 1);

            if(nextChapter != null)
            {
                return RedirectToAction("Audit", "Chapter", new { id = nextChapter.Id });
            }

            else
            {
                return RedirectToAction("Audit", "FinalPage", new { id = currentCourse.FinalPage.Id });
            }
        }

        public async Task<IActionResult> Audit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizPage = await _context.QuizPage.FirstOrDefaultAsync(m => m.Id == id);

            if (quizPage == null)
            {
                return NotFound();
            }

            return View(quizPage);
        }

        // GET: QuizPage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuizPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Content")] QuizPage quizPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quizPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quizPage);
        }

        // GET: QuizPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizPage = await _context.QuizPage.FindAsync(id);
            if (quizPage == null)
            {
                return NotFound();
            }
            return View(quizPage);
        }

        // POST: QuizPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Content")] QuizPage quizPage)
        {
            if (id != quizPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizPageExists(quizPage.Id))
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
            return View(quizPage);
        }

        // GET: QuizPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizPage = await _context.QuizPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizPage == null)
            {
                return NotFound();
            }

            return View(quizPage);
        }

        // POST: QuizPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quizPage = await _context.QuizPage.FindAsync(id);
            _context.QuizPage.Remove(quizPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizPageExists(int id)
        {
            return _context.QuizPage.Any(e => e.Id == id);
        }
    }
}
