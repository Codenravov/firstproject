﻿using MVCWebProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Web;

namespace MVCWebProject.DAL.Repositories
{
    public class EntitiesRepository<T> : IRepository<T> where T : class
    {
        private EntitiesContext _dataContext;
        private readonly DbSet<T> _dbset;

        public EntitiesRepository(EntitiesContext context)
        {
            this._dataContext = context;
            this._dbset = context.Set<T>();
        }


        public virtual List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);

            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }

        public int Count(Expression<Func<T, bool>> where = null)
        {
            return _dbset.Count(where);
        }

        public bool IsExist(Expression<Func<T, bool>> where = null)
        {
            return _dbset.FirstOrDefault(where) != null ? true : false;
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}