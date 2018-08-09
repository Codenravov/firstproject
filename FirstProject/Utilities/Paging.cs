using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCWebProject.Utilities
{

    public interface IPagingList<T>
    {
        int CurrentPage { get; }

        int TotalPage { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        List<T> Items { get; }

        PagedList<T> CreatePage(IEnumerable<T> source, int page, int pageSize);

        PagedList<T> CreatePage(IQueryable<T> source, int page, int pageSize);
    }

    public class PagedList<T> : IPagingList<T>
    {
        public int CurrentPage { get; private set; }

        public int TotalPage { get; private set; }

        public bool HasPreviousPage { get; private set; }

        public bool HasNextPage { get; private set; }

        public List<T> Items { get; private set; }

        public PagedList<T> CreatePage(IEnumerable<T> source, int page, int pageSize) => this.CreatePage(source.AsQueryable(), page, pageSize);

        public PagedList<T> CreatePage(IQueryable<T> source, int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException("Page", "Value can not be less than 1");
            }

            if (source == null)
            {
                source = new List<T>().AsQueryable();
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize", "Value can not be less than 1");
            }

            PagedList<T> pagedList = new PagedList<T>
            {
                CurrentPage = page,
                TotalPage = source.Count() > 0 ? (int)Math.Ceiling(source.Count() / (double)pageSize) : 0,
                HasPreviousPage = page > 1,
                HasNextPage = page < this.TotalPage,
                Items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            };
            return pagedList;
        }
    }
}