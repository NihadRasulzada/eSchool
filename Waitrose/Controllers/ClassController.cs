using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class ClassController : Controller
    {
        private readonly AppDbContext _db;
        public ClassController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Class> classes = await _db.Classes.ToListAsync();
            return View(classes);
        }

        #region Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Class @class)
        {
            await _db.Classes.AddAsync(@class);
            await _db.SaveChangesAsync();
            return RedirectToAction("ManageClass", "Classroom");
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Class @class = await _db.Classes.FirstOrDefaultAsync(x => x.Id == id);
            if (@class == null)
            {
                return BadRequest();
            }

            if (!@class.isDeactive)
            {
                @class.isDeactive = true;
            }
            else
            {
                @class.isDeactive = false;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
        public async Task<IActionResult> AsignClassTeacher()
        {
            ViewBag.Classes = await _db.Classes.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignClassTeacher(int classId, int subjectId, int teacherId)
        {
            ViewBag.Classes = await _db.Classes.ToListAsync();
            Class @class = await _db.Classes.Include(x => x.TeacherClasses).FirstOrDefaultAsync(x => x.Id == classId);
            TeacherClass teacherClass = new TeacherClass
            {
                ClassId = classId,
                TeacherId = teacherId
            };
            @class.TeacherClasses.Add(teacherClass);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LoadSubject(int classId)
        {
            List<int> ids = new List<int>();
            List<Subject> dbSubjects = await _db.Subjects.ToListAsync();
            List<TeacherClass> teacherClasses = (await _db.Classes.Include(x => x.TeacherClasses).ThenInclude(x => x.Teacher).ThenInclude(x => x.Subject).FirstOrDefaultAsync(x => x.Id == classId)).TeacherClasses;
            foreach (TeacherClass item in teacherClasses)
            {
                ids.Add(item.Teacher.SubjectId);
            }
            List<Subject> subjects = new List<Subject>();
            bool isBool = false;
            foreach (Subject item in dbSubjects)
            {
                isBool = false;
                foreach (int Id in ids)
                {
                    if(item.Id == Id)
                    {
                        isBool = true;
                    }
                }
                if (!isBool)
                {
                    subjects.Add(item);
                }
            }
            return PartialView("_LoadSubjectPartial",subjects );
        }
        public async Task<IActionResult> LoadTeacher(int subjectId)
        {
            List<Teacher> teachers = await _db.Teachers.Where(x => x.SubjectId == subjectId).ToListAsync();
            return PartialView("_LoadTeacherPartial", teachers);
        }

    }
}
