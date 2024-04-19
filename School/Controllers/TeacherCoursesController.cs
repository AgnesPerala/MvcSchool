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
    public class TeacherCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherCourses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherCourses.Include(t => t.Course).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherCourseId == id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            return View(teacherCourse);
        }

        // GET: TeacherCourses/Create
        public IActionResult Create()
        {
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName");
            return View();
        }

        // POST: TeacherCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherCourseId,FkCourseId,FkTeacherId")] TeacherCourse teacherCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", teacherCourse.FkCourseId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName", teacherCourse.FkTeacherId);
            return View(teacherCourse);
        }

        // GET: TeacherCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses.FindAsync(id);
            if (teacherCourse == null)
            {
                return NotFound();
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", teacherCourse.FkCourseId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName", teacherCourse.FkTeacherId);
            return View(teacherCourse);
        }

        // POST: TeacherCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherCourseId,FkCourseId,FkTeacherId")] TeacherCourse teacherCourse)
        {
            if (id != teacherCourse.TeacherCourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherCourseExists(teacherCourse.TeacherCourseId))
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
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", teacherCourse.FkCourseId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName", teacherCourse.FkTeacherId);
            return View(teacherCourse);
        }

        // GET: TeacherCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherCourseId == id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            return View(teacherCourse);
        }

        // POST: TeacherCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherCourse = await _context.TeacherCourses.FindAsync(id);
            if (teacherCourse != null)
            {
                _context.TeacherCourses.Remove(teacherCourse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherCourseExists(int id)
        {
            return _context.TeacherCourses.Any(e => e.TeacherCourseId == id);
        }
    }
}
