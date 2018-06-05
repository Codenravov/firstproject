﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebProject.Utilities
{
    public interface IPagingList<T>
    {
        void CreatePage(IEnumerable<T> source, int page, int pageSize);
        void CreatePage(IQueryable<T> source, int page, int pageSize);
        int CurrentPage { get; }
        int TotalPage { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        List<T> Items { get; }
    }
    public class PagedList<T> : IPagingList<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPage { get; private set; }
        public bool HasPreviousPage { get; private set; }
        public bool HasNextPage { get; private set; }
        public List<T> Items { get; private set; }


        public void CreatePage(IEnumerable<T> source, int page, int pageSize) => CreatePage(source.AsQueryable(), page, pageSize);
        public void CreatePage(IQueryable<T> source, int page, int pageSize)
        {
            if (page < 1) throw new ArgumentOutOfRangeException("page", "Value can not be less than 1");

            if (source == null) source = new List<T>().AsQueryable();

            if (pageSize < 1) throw new ArgumentOutOfRangeException("pageSize", "Value can not be less than 1");

            CurrentPage = page;
            TotalPage = source.Count() > 0 ? (int)Math.Ceiling(source.Count() / (double)pageSize) : 0;
            HasPreviousPage = page > 1;
            HasNextPage = page < TotalPage;
            Items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        }
    }
}