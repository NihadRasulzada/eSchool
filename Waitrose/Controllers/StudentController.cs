using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Helper;
using Waitrose.Models;
using Waitrose.ViewModel;

namespace Waitrose.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public StudentController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        #region AddStudent
        public async Task<IActionResult> AddStudent()
        {
            ViewBag.Classes = await _db.Classes.Where(x => !x.isDeactive).ToListAsync();
            ViewBag.Parents = await _db.Parents.Where(x => !x.isDeactive).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(AddStudentVM addStudentVM, int isMaleId, int classId, int sectionId, int[] parentsId)
        {
            ViewBag.Classes = await _db.Classes.Where(x => !x.isDeactive).ToListAsync();
            ViewBag.Parents = await _db.Parents.Where(x => !x.isDeactive).ToListAsync();

            AppUser newUser = new AppUser
            {
                UserName = addStudentVM.Username,
                Email = addStudentVM.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, addStudentVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            else
            {
                Student student = new Student
                {
                    FullName = addStudentVM.FullName,
                    Username = addStudentVM.Username,
                    EmailAddress = addStudentVM.Email,
                    DateOfBirth = addStudentVM.DateOfBirth,
                    Address = addStudentVM.Address,
                    PhoneNumber = addStudentVM.PhoneNumber,
                    isMale = Convert.ToBoolean(isMaleId),
                    ClassId = classId,
                };

                List<StudentParent> studentParents = new List<StudentParent>();
                foreach (int item in parentsId)
                {
                    StudentParent studentParent = new StudentParent
                    {
                        ParentId = item,
                    };
                    studentParents.Add(studentParent);
                }
                student.StudentParents = studentParents;
                await _db.Students.AddAsync(student);
            }
            await _userManager.AddToRoleAsync(newUser, Roles.Student.ToString());
            await _db.SaveChangesAsync();
            return RedirectToAction("AddStudent");
        }

        #endregion    

        public async Task<IActionResult> ViewStudent()
        {
            List<Student> students = await _db.Students.Include(x => x.Class).ToListAsync();
            return View(students);
        }

        public async Task<IActionResult> StudentProfile(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Student student = await _db.Students.Include(x => x.Class).Include(x=>x.StudentParents).ThenInclude(x=>x.Parent).FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            StudentProfileVM studentProfileVM = new StudentProfileVM
            {
                Email = student.EmailAddress,
                PhoneNumber = student.PhoneNumber,
                FullName = student.FullName,
                DateofBirth = student.DateOfBirth,
                Class = student.Class.Name,
                Address = student.Address,
                UserName = student.Username,
                ParentNames = new List<string>(),
                isMale = student.isMale
            };
            foreach (StudentParent item in student.StudentParents)
            {
                studentProfileVM.ParentNames.Add(item.Parent.FullName);
            }
            return View(studentProfileVM);
        }
    }

}
