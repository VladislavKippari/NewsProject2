using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News.Models;
using NewsApp.Domain.Entities;
using NewsApp.Persistence;

namespace News.Controllers
{

    public class AccountController : Controller
    {
        private NewsAppDbContext db;
        public AccountController(NewsAppDbContext context)
        {
            db = context;
        }
        string startupPath = Environment.CurrentDirectory;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.Include(u => u.Role).
                    FirstOrDefaultAsync(u => u.Email == model.Email
                            && u.Password == PasswordGenerate.HashPassword(model.Password));

                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
          
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            model.RoleName = new SelectList(db.Roles.OrderBy(o => o.RoleName).ToList(), "RoleId", "RoleName", 1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    Role role = new Role();
                    // добавляем пользователя в бд
                    if (User.IsInRole("Admin"))
                    {
                         role = db.Roles.Find(model.RoleId);
                    }
                    else
                    {
                         role = await db.Roles.FirstOrDefaultAsync(r => r.RoleName == "User");
                    }
                   
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = PasswordGenerate.HashPassword(model.Password),
                        Role = role ?? null
                    };
                    db.Users.Add(user);
                    await db.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Такой пользователь уже существует");
            }
           

            return View(model);

        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.RoleName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}