using Microsoft.AspNetCore.Mvc;
using Waitrose.DAL;

namespace Waitrose.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        public IActionResult ViewStudent()
        {
            return View();
        }
    }
}
