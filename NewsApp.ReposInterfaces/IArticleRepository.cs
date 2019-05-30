using System;
using System.Collections.Generic;
using System.Text;
using NewsApp.ReposInterfaces.Base;
using NewsApp.Domain.Entities;

namespace NewsApp.ReposInterfaces
{
    public interface IArticleRepository : IRepository<Article>, IKeyRepository<Article, int>
    {
        List<Article> GetArticlesByTitle(string title);
        Article FindById(int id);
    }
}
