using Microsoft.AspNetCore.Mvc;
using Waitrose.DAL;
using Waitrose.Models;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student student)
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ViewStudent()
        {
            return View();
        }
    }
}
