using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVCWebProjectDAL.Interfaces
{

    public interface IRepository<T>
    {
        List<T> Get(Expression<Func<T, bool>> filter = null, Func<T, object> orderBy = null);
        T Get(Expression<Func<T, bool>> where);

        bool IsExist(Expression<Func<T, bool>> where = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);

        void Save();
    }
}