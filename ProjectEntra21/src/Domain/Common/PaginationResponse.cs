using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Domain.Common
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }

        public PaginationResponse(IEnumerable<T> items, int totalItems, int currentPage, int pageSize)
        {
            Data = items;
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}