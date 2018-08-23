using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCWebProject.Utilities
{
    public class PagingList<T> : IPagingList<T>
    {
        public int CurrentPage { get; private set; }

        public int TotalPage { get; private set; }

        public List<T> Items { get; private set; }

        public PagingList<T> CreatePage(IEnumerable<T> source, int page, int pageSize)
        {
            return this.CreatePage(source.AsQueryable(), page, pageSize);
        }

        public PagingList<T> CreatePage(IQueryable<T> source, int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException("page", "Value can not be less than 1");
            }

            if (source == null)
            {
                source = new List<T>().AsQueryable();
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize", "Value can not be less than 1");
            }

            CurrentPage = page;
            TotalPage = source.Count() > 0 ? (int)Math.Ceiling(source.Count() / (double)pageSize) : 1;
            if (CurrentPage > TotalPage)
            {
                throw new ArgumentOutOfRangeException("CurrentPage", "Value can not be more than total number of pages");
            }

            Items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PagingList<T> pagingList = new PagingList<T>
            {
                CurrentPage = this.CurrentPage,
                TotalPage = this.TotalPage,
                Items = this.Items
            };
            return pagingList;
        }
    }
}