using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class ViewMarksController : Controller
    {
        private readonly AppDbContext _db;
        public ViewMarksController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            ViewBag.Classes = await _db.Classes.ToListAsync();
            ViewBag.Exams = await _db.Exams.ToListAsync();
            List<Mark> marks = await _db.Marks
                .Include(x => x.Student)
                .ThenInclude(x => x.Class)
                .Include(x => x.Subject)
                .Include(x => x.Exam)
                .ToListAsync();
            return View(marks);
        }
        #endregion

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

        public async Task<IActionResult> LoadStudentWithMark(int classId, int examId, int subjectId)
        {
            List<Mark> marks = await _db.Marks
                .Include(x => x.Student)
                .ThenInclude(x => x.Class)
                .Include(x => x.Subject)
                .Include(x => x.Exam)
                .Where(x => x.ExamId == examId && x.SubjectId == subjectId && x.Student.ClassId == classId)
                .ToListAsync();
            return PartialView("_LoadStudentWithMarkPartial", marks);
        }


    }
}
