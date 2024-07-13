using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Controllers
{
    [Authorize(Roles="Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();//takes a list of the roles in db
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", await roleManager.Roles.ToListAsync());
            }


            if (await roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name", "Role already exists!");
                return View("Index", await roleManager.Roles.ToListAsync());
            }

            await roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound();
            }

            var vm = new EditRoleViewModel { Id = roleId, Name = role.Name };
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {

            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                return NotFound();
            }

            var roleSame = await roleManager.FindByNameAsync(model.Name);
            if (roleSame != null && roleSame.Id != model.Id)
            {
                ModelState.AddModelError("Name", "Sorry! This name is already assigned to another role");
                return View(model);
            }

            role.Name = model.Name;
            await roleManager.UpdateAsync(role);
            return RedirectToAction(nameof(Index));


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }

            var result = await roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Delete", "An error occurred while deleting the user.");
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
