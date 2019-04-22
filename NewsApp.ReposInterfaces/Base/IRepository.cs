using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.ReposInterfaces.Base
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
