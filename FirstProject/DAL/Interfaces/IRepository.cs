using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVCWebProject.DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IQueryable<T>> orderBy = null);

        void Add(T entity);

        void Update(T entity);
        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);

        T Get(Expression<Func<T, bool>> where);

        int Count(Expression<Func<T, bool>> where = null);

        bool IsExist(Expression<Func<T, bool>> where = null);

        void Save();
    }
}