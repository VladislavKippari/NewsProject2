using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Models;
using NewsApp.Persistence;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private NewsAppDbContext db;
        public HomeController(NewsAppDbContext context)
        {
            db = context;
        }
        string startupPath = Environment.CurrentDirectory;


        public IActionResult Index()
        {
            var article = db.Articles
                .Include("Article")
                .Select(a => new ArticleViewModel
                {
                    ArticleId = a.ArticleId,
                    Image = a.Image,
                    Title = a.Title
                });

            return View(article);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            var users = db.Users.Include(r => r.Role).ToList();
            ViewBag.Users = users;
            return View();
        }

        [Authorize(Policy = "OnlyForAdmin")]
        public IActionResult Policy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
