using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project01.Models;
using project01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UsersController(UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.Select(user=>new UsersViewModel
            {
                Id = user.Id,
                FirstName=user.FirstName,
                LastName=user.LastName,
                UserName=user.UserName,
                UserEmail=user.Email,
                Roles = userManager.GetRolesAsync(user).Result
            }).ToListAsync();
            return View(users);
        }


        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.Select(r=>new RolesViewModel { RoleID = r.Id, RoleName=r.Name }).ToListAsync();
            var vm = new AddUserViewModel
            {
                Roles = roles
            };
            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!model.Roles.Any(r => r.isSelected))
            {
                ModelState.AddModelError("Roles", "Please select at least one role");
                return View(model);
            }

            if(await userManager.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", "Email is already used!");
                return View(model);
            }

            if (await userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "Username is already used!");
                return View(model);
            }

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age=model.Age
            };

            var result = await userManager.CreateAsync(user, model.Password);//creates the user

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Roles", error.Description);
                }
                return View(model);
            }

            await userManager.AddToRolesAsync(user, model.Roles.Where(r=>r.isSelected).Select(r=>r.RoleName));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var vm = new ProfileFormViewModel
            {
                ID=user.Id,
                FirstName=user.FirstName,
                LastName=user.LastName,
                UserName=user.UserName,
                Age=user.Age,
                Email=user.Email
            };
            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByIdAsync(model.ID);
            if (user == null)
            {
                return NotFound();
            }

            var userSameEmail = await userManager.FindByEmailAsync(model.Email);
            if (userSameEmail != null && userSameEmail.Id != model.ID)
            {
                ModelState.AddModelError("Email", "Sorry! This email is already assigned to another user");
                return View(model);
            }


            var userSameUserName = await userManager.FindByNameAsync(model.UserName);
            if (userSameUserName != null && userSameUserName.Id != model.ID)
            {
                ModelState.AddModelError("UserName", "Sorry! This username is already assigned to another user");
                return View(model);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.Age = model.Age;
            user.Email = model.Email;

            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var roles = await roleManager.Roles.ToListAsync();
            var vm = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RolesViewModel
                {
                    RoleID=role.Id,
                    RoleName=role.Name,
                    isSelected=userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName)&&!role.isSelected)
                {
                    await userManager.RemoveFromRoleAsync(user, role.RoleName);
                }

                if (!userRoles.Any(r => r == role.RoleName) && role.isSelected)
                {
                    await userManager.AddToRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Delete", "An error occurred while deleting the user.");
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
