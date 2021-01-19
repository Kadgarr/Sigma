using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesShop.Models;
using GamesShop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GamesShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        GamesShopDB_Context db = new GamesShopDB_Context();

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               

                User user = new User { Email = model.Email, UserName = model.Fio, ID_Card = int.Parse(model.ID_Card), };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    await RoleInitializer.InitializeUserAsync(user, _userManager);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout(string returnUrl = null)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ActionName("_Layout")]
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            ViewData["User logout"]="User logout";
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string name)
        {
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(User getuser)
        {
            User user = await _userManager.FindByNameAsync(getuser.UserName);
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    user.Email = getuser.Email;
                    //user.UserName = getuser.UserName;
                    user.Year = getuser.Year;
                    user.ID_Card = getuser.ID_Card;

                    db.Users.Update(user);
                    await db.SaveChangesAsync();

                        ViewData["MsgSaveEditUser"] = "Измененные данные успешно сохранены!";
                         return View(user);
                    
                   
                }
            }
            return View(user);


        }
    }
}
