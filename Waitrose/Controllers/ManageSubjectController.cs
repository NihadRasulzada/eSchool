using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class ManageSubjectController : Controller
    {
        private readonly AppDbContext _db;
        public ManageSubjectController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Subject> subjects = await _db.Subjects.Include(x => x.Teachers).ToListAsync();
            return View(subjects);
        }

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Subject dbSubject = await _db.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if (dbSubject == null)
            {
                return NotFound();
            }
            return View(dbSubject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Subject subject)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Subject dbSubject = await _db.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if (dbSubject == null)
            {
                return NotFound();
            }

            dbSubject.Name = subject.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        } 
        #endregion

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subject subject)
        {
            await _db.Subjects.AddAsync(subject);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
