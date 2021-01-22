using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesShop.Models;
using GamesShop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesShop.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        GamesShopDB_Context db = new GamesShopDB_Context();
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        } 
        public IActionResult IndexRoles() => View(_roleManager.Roles.ToList());
        public IActionResult UserList() => View(_userManager.Users.ToList());

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, Year = user.Year };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Year = model.Year;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserList");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return RedirectToAction("UserList");

        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("UserList");
        }

        public IActionResult CreateRoles() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRoles(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("IndexRoles");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRoles(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("IndexRoles");
        }

  

        [HttpGet]
        public async Task<IActionResult> EditRoles(string userId)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditRoles(string userId, /*List<string> roles*/ List<string> roleId)
        {

            try
            {
                using (GamesShopDB_Context db = new GamesShopDB_Context())
                {

                    var userRoles = db.UserRoles.Where(p => p.UserId == userId).Select(x => x.RoleId);


                    var addedRoles = roleId.Except(userRoles);

                    var removedRoles = userRoles.ToList().Except(roleId);

                    foreach (var ur in addedRoles)
                    {
                        IdentityUserRole<string> userrole = new IdentityUserRole<string>()
                        {
                            UserId = userId,
                            RoleId = ur
                        };

                        await db.UserRoles.AddAsync(userrole);
                        await db.SaveChangesAsync();
                    }

                    foreach (var ur in removedRoles)
                    {
                        IdentityUserRole<string> userroledelete = new IdentityUserRole<string>()
                        {
                            UserId = userId,
                            RoleId = ur
                        };
                        db.UserRoles.Remove(userroledelete);
                        await db.SaveChangesAsync();
                    }

                    return RedirectToAction("UserList");
                }
            }
            catch
            {
                return NotFound();
            }
             

        }
    }
}
