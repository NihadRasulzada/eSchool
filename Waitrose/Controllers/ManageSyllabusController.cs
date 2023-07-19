using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Helper;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class ManageSyllabusController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ManageSyllabusController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Classes = await _db.Classes.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, int classId, int subjectId)
        {
            if ((file == null || file.Length == 0) && classId == 0 && subjectId == 0)
            {
                return BadRequest("Please select items.");
            }

            Syllabus syllabus = new Syllabus();
            syllabus.Document = file;

            string folder = Path.Combine(_env.WebRootPath, "assets", "images");
            syllabus.File = await syllabus.Document.SaveFileAsync(folder);

            syllabus.ClassId = classId;
            syllabus.SubjectId = subjectId;
            syllabus.Downloaded = 0;
            await _db.Syllabuses.AddAsync(syllabus);
            await _db.SaveChangesAsync();
            return Content("Ok");
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

        public async Task<IActionResult> LoadSyllabuses(int classId, int subjectId)
        {
            if (subjectId == 0 || classId == 0)
            {
                return BadRequest();
            }
            List<Syllabus> syllabuses = await _db.Syllabuses
                .Where(x => x.ClassId == classId && x.SubjectId == subjectId).ToListAsync();
            return PartialView("_LoadSyllabusesPartial", syllabuses);
        }

    }
}
