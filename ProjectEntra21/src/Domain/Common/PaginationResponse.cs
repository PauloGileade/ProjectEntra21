using System;
using System.Collections.Generic;

namespace ProjectEntra21.src.Domain.Common
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T> Data { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }

        public PaginationResponse(IEnumerable<T> data, int currentPage, int totalItems, int totalPages)
        {
            Data = data;
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(currentPage / (double) totalPages);
        }
    }
}
