using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Domain.Entities;
using NewsApp.Persistence;
using NewsApp.ReposInterfaces;

namespace News.Controllers
{
    public class CreateArticleController : Controller
    {

        IArticleRepository articleRepo;
        NewsAppDbContext test = new NewsAppDbContext();
        public CreateArticleController(IArticleRepository ar)
        {

            articleRepo = ar;
        }


        string connectionString = @"Server=(localdb)\mssqllocaldb;Database=NewsAppDB;Trusted_Connection=True;";

        public IActionResult CreateArticle()
        {

            return View();
        }
     


        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormCollection form, string testTitle, string Text)
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

            StoreInDB(storePath + form.Files[0].FileName, testTitle, Text);

            return RedirectToAction("CreateArticle");

        }


        public void StoreInDB(string path, string testTitle, string Text)
        {

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();


                using (var command = con.CreateCommand())
                {
                    command.CommandText = "insert into Article(Image) values('" + path + "')";
                    command.ExecuteNonQuery();


                }



            }
            int lol = test.Articles.Count();
            var article =
            from articl in test.Articles
            where articl.ArticleId == test.Articles.Count()
            select articl;
            var art = test.Articles.Where(w => w.ArticleId == test.Articles.Count()).FirstOrDefault();


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
    }
}