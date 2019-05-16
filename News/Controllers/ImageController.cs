using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Domain.Entities;
using NewsApp.ReposInterfaces;

namespace News.Controllers
{
    public class ImageController : Controller
    {
        IUserRepository articleRepo;
        public ImageController(IUserRepository ar)
        {

            articleRepo = ar;
        }




        public IActionResult Testing()
        {
            List<User> liss = articleRepo.GetAll().ToList();
            return View(liss);
        }




    }
}