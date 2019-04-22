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
    public class JournalistRepository : IJournalistRepository
    {
        NewsAppDbContext context;

        public void Add(Journalist entity)
        {
            context.Journalists.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Journalist entity)
        {
            context.Journalists.Find(entity.JournalistId);
            context.Journalists.Remove(entity);
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

        public void Edit(Journalist entity)
        {
            var originalEntity = context.Journalists.Find(entity.JournalistId);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }

        public IEnumerable<Journalist> FindBy(Func<Journalist, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<Journalist> GetAll()
        {
            var journalists = context.Journalists;
            return journalists.AsQueryable<Journalist>();
        }

        public Journalist GetSingle(int entityKey)
        {
            return context.Journalists.Where(j => j.JournalistId == entityKey)
                .SingleOrDefault();
        }
    }
}
