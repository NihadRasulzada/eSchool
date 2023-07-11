using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class EntryMarksController : Controller
    {
        private readonly AppDbContext _db;
        public EntryMarksController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Classes = await _db.Classes.ToListAsync();
            ViewBag.Exams = await _db.Exams.ToListAsync();
            return View();
        }

        #region LoadSubject
        public async Task<IActionResult> LoadSubject(int classId)
        {
            List<TeacherClass> teacherClasses = (await _db.Classes
                .Include(x => x.TeacherClasses)
                .ThenInclude(x => x.Teacher)
                .ThenInclude(x => x.Subject)
                .FirstOrDefaultAsync(x => x.Id == classId))
                .TeacherClasses.ToList();
            List<Subject> subjects = new List<Subject>();
            foreach (TeacherClass item in teacherClasses)
            {
                subjects.Add(item.Teacher.Subject);
            }
            return PartialView("_LoadSubjectPartial", subjects);
        }
        #endregion

        public async Task<IActionResult> LoadStudentsForMark(int classId, int subjectId, int examId)
        {
            
            return PartialView("_LoadStudentsForMarkPartial",);
        }
    }
}
