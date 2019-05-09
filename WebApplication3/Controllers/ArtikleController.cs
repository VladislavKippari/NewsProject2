using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Domain.Entities;
using NewsApp.ReposInterfaces;

namespace WebApplication3.Controllers
{
    public class ArtikleController : Controller
    {
        IArticleRepository articleRepository;

        public ArtikleController(IArticleRepository art)
        {
            articleRepository = art;
        }
        public IActionResult Index()
        {
            List<Article> list = articleRepository.GetAll().ToList();
            return View(list);
         
        }
    }
}