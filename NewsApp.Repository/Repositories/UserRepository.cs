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
    public class UserRepository : IUserRepository
    {
        NewsAppDbContext context;
        public UserRepository(NewsAppDbContext context)
        {
            this.context = context;
        }
        public void Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.Users.Find(entity.UserId);
            context.Users.Remove(entity);
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

        public void Edit(User entity)
        {
            var originalEntity = context.Users.Find(entity.UserId);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }

        public IEnumerable<User> FindBy(Func<User, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<User> GetAll()
        {
            var users = context.Users;
            return users.AsQueryable<User>();
        }

        public User GetSingle(int entityKey)
        {
            return context.Users.Where(u => u.UserId == entityKey)
                .SingleOrDefault();
        }
    }
}
