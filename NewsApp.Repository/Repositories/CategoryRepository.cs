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
    public class CategoryRepository : ICategoryRepository
    {
        NewsAppDbContext context;
     


        public CategoryRepository(NewsAppDbContext context)
        {
            this.context = context;
        }
        public void Add(Category entity)
        {
            context.Categorys.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            context.Categorys.Find(entity.CategoryId);
            context.Categorys.Remove(entity);
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

        public void Edit(Category entity)
        {
            var originalEntity = context.Categorys.Find(entity.CategoryId);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }

        public IEnumerable<Category> FindBy(Func<Category, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = context.Categorys;
            return categories.AsQueryable<Category>();
        }

        public Category FindById(int id)
        {
            return context.Categorys.Where(c => c.CategoryId == id).SingleOrDefault();
               
        }
        public Category GetSingle(int entityKey)
        {
            return context.Categorys.Where(c => c.CategoryId == entityKey)
                .SingleOrDefault();
        }
    }
}
