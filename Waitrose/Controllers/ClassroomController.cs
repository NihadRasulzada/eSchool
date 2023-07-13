using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;
using Waitrose.ViewModel;

namespace Waitrose.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly AppDbContext _db;
        public ClassroomController(AppDbContext db)
        {
            _db = db;
        }

        #region ManageClass
        public async Task<IActionResult> ManageClass()
        {
            List<Class> classes = await _db.Classes.Include(x => x.TeacherClasses).ThenInclude(x => x.Teacher).ThenInclude(x => x.Subject).ToListAsync();
            return View(classes);
        }
        #endregion

        #region ClassProfile
        public async Task<IActionResult> ClassProfile(int? classId, int subjectId)
        {
            List<Teacher> teachers = (await _db.Subjects
                 .Include(x => x.Teachers)
                 .ThenInclude(x => x.TeacherClasses)
                 .ThenInclude(x => x.Class)
                 .ThenInclude(x => x.Students)
                 .FirstOrDefaultAsync(x => x.Id == subjectId))
                 .Teachers.ToList();
            Class @class = new Class();
            foreach (Teacher teacher in teachers)
            {
                foreach (TeacherClass teacherClass in teacher.TeacherClasses)
                {
                    if (teacherClass.ClassId == classId)
                    {
                        @class = teacherClass.Class;
                    }
                }
            }
            return View(@class);
        }
        #endregion

        public async Task<IActionResult> Evaluation(int? classId, int subjectId)
        {
            if (classId == null || subjectId == null)
            {
                return NotFound();
            }
            List<Teacher> teachers = (await _db.Subjects
                 .Include(x => x.Teachers)
                 .ThenInclude(x => x.TeacherClasses)
                 .ThenInclude(x => x.Class)
                 .ThenInclude(x => x.Students)
                 .FirstOrDefaultAsync(x => x.Id == subjectId))
                 .Teachers.ToList();
            Class @class = new Class();
            foreach (Teacher teacher in teachers)
            {
                foreach (TeacherClass teacherClass in teacher.TeacherClasses)
                {
                    if (teacherClass.ClassId == classId)
                    {
                        @class = teacherClass.Class;
                    }
                }
            }
            if (@class == null)
            {
                return BadRequest();
            }
            ViewBag.Student = @class.Students;
            ViewBag.Exam = await _db.Exams.ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Evaluation(int? classId, int subjectId, Mark mark, int studentId, int examId)
        {
            if (classId == null || subjectId == null)
            {
                return NotFound();
            }
            List<Teacher> teachers = (await _db.Subjects
                 .Include(x => x.Teachers)
                 .ThenInclude(x => x.TeacherClasses)
                 .ThenInclude(x => x.Class)
                 .ThenInclude(x => x.Students)
                 .FirstOrDefaultAsync(x => x.Id == subjectId))
                 .Teachers.ToList();
            Class @class = new Class();
            foreach (Teacher teacher in teachers)
            {
                foreach (TeacherClass teacherClass in teacher.TeacherClasses)
                {
                    if (teacherClass.ClassId == classId)
                    {
                        @class = teacherClass.Class;
                    }
                }
            }
            if (@class == null)
            {
                return BadRequest();
            }
            ViewBag.Student = @class.Students;
            ViewBag.Exam = await _db.Exams.ToListAsync();

            mark.SubjectId = subjectId;
            mark.StudentId = studentId;
            mark.ExamId = examId;   

            await _db.Marks.AddAsync(mark);
            await _db.SaveChangesAsync();
            return RedirectToAction("ManageClass");
        }


    }
}
