using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class SectionController : Controller
    {
        private readonly AppDbContext _db;
        public SectionController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Section> sections = await _db.Sections.ToListAsync();
            return View(sections);
        }

        #region Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Section section)
        {
            if (section.Name == null)
            {
                ModelState.AddModelError("Name", "Bu Xana Bosh Ola Bilmez");
            }
            _db.Sections.Add(section);
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
            Section dbSection = await _db.Sections.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dbSection == null)
            {
                return NotFound();
            }
            return View(dbSection);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(int? id, Section section)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Section dbSection = await _db.Sections.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dbSection == null)
            {
                return NotFound();
            }
            dbSection.Name = section.Name;
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
            Section section = await _db.Sections.FirstOrDefaultAsync(x => x.Id == id);
            if (section == null)
            {
                return BadRequest();
            }

            if (!section.isDeactive)
            {
                section.isDeactive = true;
            }
            else
            {
                section.isDeactive = false;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
