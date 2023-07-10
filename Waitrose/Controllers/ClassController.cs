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
        public async Task<IActionResult> Create(Class @class, int[] sectionsId)
        {
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
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbClass == null)
            {
                return NotFound();
            }
            return View(dbClass);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Class @class)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Class dbClass = await _db.Classes
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbClass == null)
            {
                return NotFound();
            }

            dbClass.Name = @class.Name;

            

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
