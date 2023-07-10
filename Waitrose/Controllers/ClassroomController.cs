using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly AppDbContext _db;
        public ClassroomController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> ManageClass()
        {
            List<Class> classes = await _db.Classes.Include(x=>x.TeacherClasses).ThenInclude(x=>x.Teacher).ToListAsync();
            return View(classes);
        }
        public async Task<IActionResult> ClassProfile(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Class @class = await _db.Classes
                .Include(x => x.TeacherClasses)
                .ThenInclude(x => x.Teacher)
                .ThenInclude(x => x.Subject)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (@class == null)
            {
                return NotFound();
            }
            return View(@class);
        }
        
    }
}
