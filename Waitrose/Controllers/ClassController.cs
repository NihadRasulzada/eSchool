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
            List<Class> classes = await _db.Classes
                .Include(x => x.ClassSections)
                .ThenInclude(x => x.Section)
                .ToListAsync();
            return View(classes);
        }

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Sections = await _db.Sections.Where(x => !x.isDeactive).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Class @class, int[] sectionsId)
        {
            ViewBag.Sections = await _db.Sections.Where(x => !x.isDeactive).ToListAsync();

            List<ClassSection> classSections = new List<ClassSection>();
            foreach (int item in sectionsId)
            {
                ClassSection classSection = new ClassSection
                {
                    SectionId = item,
                };
                classSections.Add(classSection);
            }
            @class.ClassSections = classSections;

            await _db.Classes.AddAsync(@class);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Class dbClass = await _db.Classes
                .Include(x => x.ClassSections)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbClass == null)
            {
                return NotFound();
            }
            ViewBag.Sections = await _db.Sections
                .Where(x => !x.isDeactive)
                .ToListAsync();
            return View(dbClass);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Class @class, int[] sectionsId)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Class dbClass = await _db.Classes
                .Include(x => x.ClassSections)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbClass == null)
            {
                return NotFound();
            }
            ViewBag.Sections = await _db.Sections
                .Where(x => !x.isDeactive)
                .ToListAsync();

            dbClass.Name = @class.Name;

            List<ClassSection> classSections = new List<ClassSection>();
            foreach (int item in sectionsId)
            {
                ClassSection classSection = new ClassSection
                {
                    SectionId = item,
                };
                classSections.Add(classSection);
            }
            dbClass.ClassSections = classSections;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
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
    }
}
