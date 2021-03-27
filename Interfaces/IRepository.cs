using System.Collections.Generic;
using System;

namespace BookStoreAPI.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        List<T> FindAll();
        List<T> FindWhere(Func<T, bool> predicate);
        T FindById(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}