using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;

namespace School.Controllers
{
    public class TeacherClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherClasses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherClasses.Include(t => t.Class).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherClass = await _context.TeacherClasses
                .Include(t => t.Class)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherClassId == id);
            if (teacherClass == null)
            {
                return NotFound();
            }

            return View(teacherClass);
        }

        // GET: TeacherClasses/Create
        public IActionResult Create()
        {
            ViewData["FkClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName");
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName");
            return View();
        }

        // POST: TeacherClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherClassId,FkClassId,FkTeacherId")] TeacherClass teacherClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", teacherClass.FkClassId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName", teacherClass.FkTeacherId);
            return View(teacherClass);
        }

        // GET: TeacherClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherClass = await _context.TeacherClasses.FindAsync(id);
            if (teacherClass == null)
            {
                return NotFound();
            }
            ViewData["FkClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", teacherClass.FkClassId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName", teacherClass.FkTeacherId);
            return View(teacherClass);
        }

        // POST: TeacherClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherClassId,FkClassId,FkTeacherId")] TeacherClass teacherClass)
        {
            if (id != teacherClass.TeacherClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherClassExists(teacherClass.TeacherClassId))
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
            ViewData["FkClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", teacherClass.FkClassId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName", teacherClass.FkTeacherId);
            return View(teacherClass);
        }

        // GET: TeacherClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherClass = await _context.TeacherClasses
                .Include(t => t.Class)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherClassId == id);
            if (teacherClass == null)
            {
                return NotFound();
            }

            return View(teacherClass);
        }

        // POST: TeacherClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherClass = await _context.TeacherClasses.FindAsync(id);
            if (teacherClass != null)
            {
                _context.TeacherClasses.Remove(teacherClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherClassExists(int id)
        {
            return _context.TeacherClasses.Any(e => e.TeacherClassId == id);
        }
    }
}
