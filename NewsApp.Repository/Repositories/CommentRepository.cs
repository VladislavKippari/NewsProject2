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
    public class CommentRepository : ICommentRepository
    {
        NewsAppDbContext context;

        public void Add(Comment entity)
        {
            context.Comments.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            context.Comments.Find(entity.CommentId);
            context.Comments.Remove(entity);
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

        public void Edit(Comment entity)
        {
            var originalEntity = context.Comments.Find(entity.CommentId);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }

        public IEnumerable<Comment> FindBy(Func<Comment, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<Comment> GetAll()
        {
            var comments = context.Comments;
            return comments.AsQueryable<Comment>();
        }

        public Comment GetSingle(int entityKey)
        {
            return context.Comments.Where(c => c.CommentId == entityKey)
                .SingleOrDefault();
        }
    }
}
