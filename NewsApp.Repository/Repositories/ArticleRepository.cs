using System;
using System.Collections.Generic;
using System.Text;
using NewsApp.Persistence;
using NewsApp.Domain.Entities;
using NewsApp.ReposInterfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NewsApp.Repository.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
         NewsAppDbContext context;

     
        public ArticleRepository(NewsAppDbContext context)
        {
            this.context =context;
        }

        public void Add(Article entity)
        {
            context.Articles.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Article entity)
        {
            context.Articles.Find(entity.ArticleId);
            context.Articles.Remove(entity);
 
        }

        public void Edit(Article entity)
        {
            var originalEntity = context.Articles.Find(entity.ArticleId);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Article> FindBy(Func<Article, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<Article> GetAll()
        {
            var articles = context.Articles;
            return articles.AsQueryable<Article>();
        }

        public List<Article> GetArticlesByTitle(string title)
        {
            if (title != null)
                return context.Articles
                    .Where(x => x.Title.ToLower().Contains(title.ToLower()))
                    .ToList();
            else return null;
        }

        public Article GetSingle(int entityKey)
        {
            return context.Articles.Where(a => a.ArticleId == entityKey)
                .SingleOrDefault();
        }

        public Article FindById(int id)
        {
            return context.Articles.Where(c => c.ArticleId == id).SingleOrDefault();
        }
    }
}
