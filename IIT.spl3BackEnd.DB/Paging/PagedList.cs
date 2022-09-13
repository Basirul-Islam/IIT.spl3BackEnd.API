using System;
using System.Collections.Generic;
using System.Linq;

namespace Cefalo.BlogSite.DB.Paging
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set;}
        public int ToatlPages { get; private set; }
        public int PageSize { get; private set; }
        public int Count { get; private set; }  

        public bool  HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < ToatlPages;

        public PagedList(List <T> items, int count, int pageNumber, int pageSize)
        {
            Count = count;
            PageSize = pageSize;
            CurrentPage = pageNumber; 
            ToatlPages = (int) Math.Ceiling(count/ (double)pageSize);
            AddRange(items);
        }
        public static PagedList<T> ToPagination(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
