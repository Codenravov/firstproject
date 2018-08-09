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

    public class EntitiesRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> dbset;
        private EntitiesContext dataContext;

        public EntitiesRepository(EntitiesContext context)
        {
            this.dataContext = context;
            this.dbset = context.Set<T>();
        }

        public virtual List<T> Get(Expression<Func<T, bool>> filter = null, Func<T, object> orderBy = null)
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

        public virtual void Add(T entity)
        {
            this.dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.dbset.Attach(entity);

            this.dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            this.dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this.dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                this.dbset.Remove(obj);
            }
        }

        public virtual T GetById(int id)
        {
            return this.dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.dbset.ToList();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return this.dbset.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return this.dbset.Where(where).FirstOrDefault<T>();
        }

        public int Count(Expression<Func<T, bool>> where = null)
        {
            return this.dbset.Count(where);
        }

        public bool IsExist(Expression<Func<T, bool>> where = null)
        {
            return this.dbset.FirstOrDefault(where) != null ? true : false;
        }

        public void Save()
        {
            this.dataContext.SaveChanges();
        }

        public virtual List<string> GetProperties()
        {
            List<string> propertiesList = new List<string>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                propertiesList.Add(property.Name);
            }

            return propertiesList;
        }
    }
}