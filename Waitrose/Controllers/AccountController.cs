using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Waitrose.Models;
using Waitrose.Helper;
using Waitrose.ViewModel;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Waitrose.Controllers
{
    public class AccountController : Controller
    {

        #region AccountController
        private readonly UserManager<AppEmployee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppEmployee> _signInManager;
        public AccountController(
            UserManager<AppEmployee> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppEmployee> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            AppEmployee appEmployee = await _userManager.FindByNameAsync(loginVM.Username);
            if (appEmployee == null)
            {
                ModelState.AddModelError("", "Username or Password is wrong");
                return View();
            }
            if (appEmployee.IsDeactive)
            {
                ModelState.AddModelError("", "Your account is deactive");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appEmployee, loginVM.Password, loginVM.IsRemember, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account is blocked");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is wrong");
                return View();
            }
            await _signInManager.SignInAsync(appEmployee, loginVM.IsRemember);
            return RedirectToAction("Index", "Home");
        } 
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        } 
        #endregion

        #region SignUp
        public IActionResult SignUp()
        {
            ViewBag.Role = new List<string>
            {
                Roles.Admin.ToString(),
                Roles.Member.ToString(),
            };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterVM registerVM, string role)
        {
            ViewBag.Role = new List<string>
            {
                Roles.Admin.ToString(),
                Roles.Member.ToString(),
            };
            AppEmployee newEmployee = new AppEmployee
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newEmployee, registerVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newEmployee, role);
            await _signInManager.SignInAsync(newEmployee, registerVM.IsRemember);
            return RedirectToAction("Index", "Home");
        } 
        #endregion

        #region CreateRoles
        public async Task CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync(Roles.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Admin.ToString() });
            }
            if (!await _roleManager.RoleExistsAsync(Roles.Member.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Member.ToString() });
            }
        }
        #endregion
    }
}
