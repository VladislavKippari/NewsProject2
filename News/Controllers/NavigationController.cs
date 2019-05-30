using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Models;
using NewsApp.Persistence;

namespace News.Controllers
{
    public class NavigationController : Controller
    {

        NewsAppDbContext db = new NewsAppDbContext();

        public ActionResult Menu()
        {
            var cat = db.Categorys
                .Include("Category")
                .Select(c => new MenuViewModel {
                    CategoryId = c.CategoryId,
                    CategoryName = c.Name
            });
            return PartialView("_Navigation", cat);
        }
    }
}