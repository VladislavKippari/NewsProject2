using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.ReposInterfaces.Base
{
    public interface IKeyRepository<T, K> : IRepository<T> where T : class
    {
        T GetSingle(K entityKey);
    }
}
