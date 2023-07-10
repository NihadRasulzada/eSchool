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
    public class ParentController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public ParentController(
            AppDbContext db,
            UserManager<AppUser> userManager
        )
        {
            _db = db;
            _userManager = userManager;
        }
        #region AddParents
        public IActionResult AddParents()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddParents(AddParentVM addParentVM, int isMaleId)
        {
            AppUser newUser = new AppUser
            {
                UserName = addParentVM.Username,
                Email = addParentVM.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, addParentVM.Password);
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
                Parent parent = new Parent
                {
                    Username = addParentVM.Username,
                    FullName = addParentVM.FullName,
                    EmailAddress = addParentVM.Email,
                    isMale = Convert.ToBoolean(isMaleId),
                    DateOfBirth = addParentVM.DateOfBirth,
                    Address = addParentVM.Address,
                    PhoneNumber = addParentVM.PhoneNumber,
                };
                await _db.Parents.AddAsync(parent);
            }
            await _userManager.AddToRoleAsync(newUser, Roles.Parent.ToString());
            await _db.SaveChangesAsync();
            return RedirectToAction("AddParents");
        }
        #endregion

        public async Task<IActionResult> ViewParents()
        {
            List<Parent> parents = await _db.Parents
                .Include(x => x.StudentParents)
                .ThenInclude(x => x.Student)
                .ToListAsync();
            return View(parents);
        }

        public async Task<IActionResult> ParentProfile(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Parent parent = await _db.Parents.Include(x => x.StudentParents).ThenInclude(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);
            if (parent == null)
            {
                return NotFound();
            }
            ParentProfileVM parentProfileVM = new ParentProfileVM
            {
                Email = parent.EmailAddress,
                PhoneNumber = parent.PhoneNumber,
                FullName = parent.FullName,
                DateofBirth = parent.DateOfBirth,
                Address = parent.Address,
                UserName = parent.Username,
                StudentNames = new List<string>(),
                isMale = parent.isMale
            };
            foreach (StudentParent item in parent.StudentParents)
            {
                parentProfileVM.StudentNames.Add(item.Student.FullName);
            }
            return View(parentProfileVM);
        }
    }
}
