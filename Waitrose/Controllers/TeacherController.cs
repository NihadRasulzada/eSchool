using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Waitrose.DAL;
using Waitrose.Models;
using Waitrose.ViewModel;
using Waitrose.Helper;
using Microsoft.EntityFrameworkCore;

namespace Waitrose.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public TeacherController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        #region AddTeacher
        public async Task<IActionResult> AddTeacher()
        {
            ViewBag.Subject = await _db.Subjects.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeacher(AddTeacherVM addTeacherVM,int subjectId, int isMaleId)
        {
            AppUser newUser = new AppUser
            {
                UserName = addTeacherVM.Username,
                Email = addTeacherVM.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, addTeacherVM.Password);
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
                Teacher teacher = new Teacher
                {
                    FullName = addTeacherVM.FullName,
                    Username = addTeacherVM.Username,
                    EmailAddress = addTeacherVM.Email,
                    DateOfBirth = addTeacherVM.DateOfBirth,
                    Address = addTeacherVM.Address,
                    PhoneNumber = addTeacherVM.PhoneNumber,
                    isMale = Convert.ToBoolean(isMaleId),
                    SubjectId = subjectId,
                };
                await _db.Teachers.AddAsync(teacher);
            }
            await _userManager.AddToRoleAsync(newUser, Roles.Teacher.ToString());
            await _db.SaveChangesAsync();
            return RedirectToAction("AddTeacher");
        }
        #endregion

        public async Task<IActionResult> ViewTeacherAsync()
        {
            List<Teacher> teachers = await _db.Teachers.ToListAsync();
            return View(teachers);
        }
    }
}
