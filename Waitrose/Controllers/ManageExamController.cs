using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class ManageExamController : Controller
    {
        private readonly AppDbContext _db;
        public ManageExamController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Exam> exams = await _db.Exams.ToListAsync();
            return View(exams);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Classes = await _db.Classes.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Exam exam)
        {
            ViewBag.Classes = await _db.Classes.ToListAsync();

            await _db.Exams.AddAsync(exam);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
