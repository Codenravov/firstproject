using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using MVCWebProjectDAL.Context;
using MVCWebProjectDAL.Interfaces;

namespace MVCWebProjectDAL.Repositories
{
    public abstract class EntityRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbSet<T> dbset;
        private readonly EntitiesContext dataContext;

        public EntityRepository(EntitiesContext context)
        {
            this.dataContext = context;
            this.dbset = context.Set<T>();
        }

        public List<T> Get(Expression<Func<T, bool>> filter = null, Func<T, object> orderBy = null)
        {
            IQueryable<T> query = this.dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                 return query.OrderBy(orderBy).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return this.dbset.Where(where).FirstOrDefault<T>();
        }

        public bool IsExist(Expression<Func<T, bool>> where = null)
        {
            return this.dbset.FirstOrDefault(where) != null ? true : false;
        }

        public void Add(T entity)
        {
            this.dbset.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            this.dbset.Attach(entity);
            this.dataContext.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this.dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                this.dbset.Remove(obj);
            }

            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbset.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return this.dbset.Where(where).ToList();
        }

        public void Save()
        {
            this.dataContext.SaveChanges();
        }
    }
}