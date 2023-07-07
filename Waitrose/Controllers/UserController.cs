using Waitrose.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waitrose.Helper;
using Waitrose.Models;

namespace Waitrose.Controllers
{
    public class UserController : Controller
    {
        #region Constructor
        private readonly UserManager<AppEmployee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppEmployee> _signInManager;
        public UserController(UserManager<AppEmployee> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppEmployee> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }
        #endregion

        #region Index
        public async Task<IActionResult> Index()
        {
            List<AppEmployee> dbUsers = await _userManager.Users.ToListAsync();
            List<UserVM> usersVM = new List<UserVM>();
            foreach (AppEmployee dbUser in dbUsers)
            {
                UserVM userVM = new UserVM
                {
                    Id = dbUser.Id,
                    Name = dbUser.Name,
                    Surname = dbUser.Surname,
                    Email = dbUser.Email,
                    Username = dbUser.UserName,
                    IsDeactive = dbUser.IsDeactive,
                    Salary = dbUser.Salary,
                    Role = (await _userManager.GetRolesAsync(dbUser))[0],
                };
                usersVM.Add(userVM);
            }
            return View(usersVM);
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppEmployee dbUser = await _userManager.FindByIdAsync(id);
            if (dbUser == null)
            {
                return BadRequest();
            }

            if (!dbUser.IsDeactive)
            {
                dbUser.IsDeactive = true;
            }
            else
            {
                dbUser.IsDeactive = false;
            }
            await _userManager.UpdateAsync(dbUser);
            return RedirectToAction("Index");
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = new List<string>
            {
                Roles.Admin.ToString(),
                Roles.Student.ToString() ,
                Roles.Teacher.ToString() ,
                Roles.Parent.ToString() ,
            };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVM createVM, string role)
        {
            ViewBag.Roles = new List<string>
            {
                Roles.Admin.ToString(),
                Roles.Student.ToString(),
                Roles.Teacher.ToString(),
                Roles.Parent.ToString(),
            };
            AppEmployee newUser = new AppEmployee
            {
                UserName = createVM.Username,
                Email = createVM.Email,
                Name = createVM.Name,
                Salary = createVM.Salary,
                Surname = createVM.Surname
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, createVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newUser, role);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(string id)
        {
            #region Get
            if (id == null)
            {
                return NotFound();
            }
            AppEmployee dbAppEmployee = await _userManager.FindByIdAsync(id);
            if (dbAppEmployee == null)
            {
                return BadRequest();
            }
            UpdateVM dbUpdateVM = new UpdateVM
            {
                Name = dbAppEmployee.Name,
                Username = dbAppEmployee.UserName,
                Email = dbAppEmployee.Email,
                Surname = dbAppEmployee.Surname,
                Salary = dbAppEmployee.Salary,
                Role = (await _userManager.GetRolesAsync(dbAppEmployee))[0],
            };
            ViewBag.Roles = new List<string>
            {
                Roles.Admin.ToString(),
                Roles.Student.ToString(),
                Roles.Teacher.ToString(),
                Roles.Parent.ToString(),
            };
            #endregion

            return View(dbUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, UpdateVM updateVM, string role)
        {
            #region Get
            if (id == null)
            {
                return NotFound();
            }
            AppEmployee dbAppEmployee = await _userManager.FindByIdAsync(id);
            if (dbAppEmployee == null)
            {
                return BadRequest();
            }
            UpdateVM dbUpdateVM = new UpdateVM
            {
                Name = dbAppEmployee.Name,
                Username = dbAppEmployee.UserName,
                Email = dbAppEmployee.Email,
                Surname = dbAppEmployee.Surname,
                Salary = dbAppEmployee.Salary,
                Role = (await _userManager.GetRolesAsync(dbAppEmployee))[0],
            };
            ViewBag.Roles = new List<string>
            {
                Roles.Admin.ToString(),
                Roles.Student.ToString(),
                 Roles.Teacher.ToString(),
                  Roles.Parent.ToString()
            };
            #endregion

            dbAppEmployee.Name = updateVM.Name;
            dbAppEmployee.UserName = updateVM.Username;
            dbAppEmployee.Surname = updateVM.Surname;
            dbAppEmployee.Email = updateVM.Email;
            dbAppEmployee.Salary = updateVM.Salary;

            if (dbUpdateVM.Role != role)
            {
                IdentityResult removeIdentityResult = await _userManager.RemoveFromRoleAsync(dbAppEmployee, dbUpdateVM.Role);
                if (!removeIdentityResult.Succeeded)
                {
                    foreach (IdentityError error in removeIdentityResult.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View();
                }
                IdentityResult addIdentityResult = await _userManager.AddToRoleAsync(dbAppEmployee, role);
                if (!addIdentityResult.Succeeded)
                {
                    foreach (IdentityError error in addIdentityResult.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            IdentityResult identityResult = await _userManager.UpdateAsync(dbAppEmployee);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                    ModelState.AddModelError("", error.Description);
                return View();
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region ResetPassword
        public async Task<IActionResult> ResetPassword(string id)
        {
            #region Get
            if (id == null)
            {
                return NotFound();
            }
            AppEmployee dbAppEmployee = await _userManager.FindByIdAsync(id);
            if (dbAppEmployee == null)
            {
                return BadRequest();
            }
            #endregion

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, ResetPasswordVM resetPasswordVM)
        {
            #region Get
            if (id == null)
            {
                return NotFound();
            }
            AppEmployee dbAppEmployee = await _userManager.FindByIdAsync(id);
            if (dbAppEmployee == null)
            {
                return BadRequest();
            }
            #endregion

            resetPasswordVM.Token = await _userManager.GeneratePasswordResetTokenAsync(dbAppEmployee);

            IdentityResult identityResult = await _userManager.ResetPasswordAsync(dbAppEmployee, resetPasswordVM.Token, resetPasswordVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
