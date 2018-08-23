using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebProject.Utilities
{
    public interface IPagingList<T>
    {
        int CurrentPage { get; }

        int TotalPage { get; }

        List<T> Items { get; }

        PagingList<T> CreatePage(IEnumerable<T> source, int page, int pageSize);

        PagingList<T> CreatePage(IQueryable<T> source, int page, int pageSize);
    }
}
