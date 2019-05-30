using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News.Models;
using NewsApp.Domain.Entities;
using NewsApp.Persistence;
using NewsApp.ReposInterfaces;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace News.Controllers
{
    public class CreateArticleController : Controller
    {

        IArticleRepository articleRepo;
        ICategoryRepository catRepo;
        IUserRepository userRepo;
        ICommentRepository commRepo;
        NewsAppDbContext test = new NewsAppDbContext();
        public CreateArticleController(IArticleRepository ar, ICategoryRepository cat, IUserRepository usr)
        {

            articleRepo = ar;
            catRepo = cat;
            userRepo = usr;
        }


        string connectionString = @"Server=(localdb)\mssqllocaldb;Database=NewsAppDB;Trusted_Connection=True;";

        public IActionResult CreateArticle()
        {
            var model = new CategoryViewModel();

            model.CategoryName = new SelectList(test.Categorys.OrderBy(o => o.Name).ToList(), "CategoryId", "Name", 1);

            return View(model);
        }
        public IActionResult Details()
        {


            var products = test.Articles
                           .Include("Article")
                           .Select(a => new ArticleViewModel
                           {
                               ArticleId = a.ArticleId,
                               Title = a.Title,
                               CreatingDate = a.CreatingDate,
                               ArticleText = a.ArticleText,
                               Image = a.Image,
                               CategoryName = catRepo.FindById(a.Category.CategoryId).Name,
                               Email = a.Journalist.Email,
                               JournalistName = userRepo.GetSingle(a.Journalist.UserId).FirstName + " " + userRepo.GetSingle(a.Journalist.UserId).LastName
                           });
            return View(products);


        }
        [HttpPost]
        public bool DeleteArticle(int id)
        {
            try
            {

                Article art = test.Articles.Where(s => s.ArticleId == id).First();
                test.Articles.Remove(art);
                test.SaveChanges();


                return true;
            }

            catch (System.Exception)
            {
                return false;
            }

        }
        public IActionResult UpdateArticle(int id)
        {
            return View(test.Articles.Where(s => s.ArticleId == id).First());
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateOneArticle(Article art)
        {
            Article d = test.Articles.Where(s => s.ArticleId == art.ArticleId).First();
            d.Title = art.Title;
            d.ArticleText = art.ArticleText;

            test.SaveChanges();
            return RedirectToAction("Details");
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormCollection form, string testTitle, string Text, CategoryViewModel model)
        {
            string storePath = "wwwroot/images/";
            if (form.Files == null || form.Files[0].Length == 0)
                return RedirectToAction("CreateArticle");


            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), storePath,
                        form.Files[0].FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await form.Files[0].CopyToAsync(stream);
            }

            StoreInDB(form.Files[0].FileName, testTitle, Text, model);

            return RedirectToAction("CreateArticle");

        }
        [HttpPost]
        public IActionResult AddArticleDb(string categoryName)
        {

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {

                    command.CommandText = "insert into Category(Name)  values('" + categoryName + "')";
                    command.ExecuteNonQuery();


                }

            }
            test.SaveChanges();
            return RedirectToAction("Details");
        }


        public void StoreInDB(string path, string testTitle, string Text, CategoryViewModel model)
        {

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {

                    command.CommandText = "insert into Article(Image)  values('" + path + "')";
                    command.ExecuteNonQuery();


                }



            }




            int curArt = test.Articles.Last().ArticleId;

            var art = test.Articles.Where(w => w.ArticleId == curArt).FirstOrDefault();

            Category cat = test.Categorys.Find(model.SelectedCategoryId);
            cat.Articles.Add(test.Articles.Find(curArt));
            var user = test.Users.Where(w => w.Email == User.Identity.Name).FirstOrDefault();
            User journ = test.Users.Find(user.UserId);

            art.Journalist = journ;
            art.Journalist.UserId = journ.UserId;
            art.Category = cat;
            art.Category.CategoryId = cat.CategoryId;
            art.Title = testTitle;
            art.ArticleText = Text;
            test.SaveChanges();
        }
        public List<string> FetchImageFromDB()
        {
            List<string> imagePath = new List<string>();

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                using (var com = new SqlCommand("select * from Article", con))
                {
                    using (var reader = com.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                imagePath.Add(reader["Image"].ToString());

                            }
                        }
                    }
                }
            }

            return imagePath;
        }

        public IActionResult ArticleInfo(int id)
        {
            dynamic models = new ExpandoObject();
            models.ArticleViewModel = test.Articles
                           .Include("Article")
                           .Select(a => new ArticleViewModel
                           {
                               ArticleId = a.ArticleId,
                               Title = a.Title,
                               CreatingDate = a.CreatingDate,
                               ArticleText = a.ArticleText,
                               Image = a.Image,
                               CategoryName = catRepo.FindById(a.Category.CategoryId).Name,
                               JournalistName = userRepo.GetSingle(a.Journalist.UserId).FirstName + " " + userRepo.GetSingle(a.Journalist.UserId).LastName
                           }).Where(a => a.ArticleId == id);

            models.CommentViewModel = test.Comments
                           .Include("Comment")
                           .Select(c => new CommentViewModel
                           {
                               CommentId = c.CommentId,
                               CommentText = c.CommentText,
                               CommenterName = userRepo.GetSingle(c.User.UserId).FirstName + " " + userRepo.GetSingle(c.User.UserId).LastName,
                               ArticleId = articleRepo.FindById(c.Article.ArticleId).ArticleId
                           }).Where(c => c.ArticleId == id);
            return View(models);
        }

        [HttpPost]
        public IActionResult AddComment(int id, string CommentText)
        {
            var user = test.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            User commentator = test.Users.Find(user.UserId);
            var article = test.Articles.Where(a => a.ArticleId == id).FirstOrDefault();
            Article articcomm = test.Articles.Find(article.ArticleId);

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "insert into Comment(CommentText, UserId, ArticleId)  values('" + CommentText + "', '" + commentator.UserId + "', '" + articcomm.ArticleId + "')";
                    command.ExecuteNonQuery();
                }
            }
            test.SaveChanges();
            return RedirectToAction("ArticleInfo/" + id);
        }

        [HttpPost]
        public bool DeleteComment(int id)
        {
            try
            {
                Comment com = test.Comments.Where(s => s.CommentId == id).First();
                test.Comments.Remove(com);
                test.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}