using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Domain.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Infrastructure.Database.Common.Extension
{
    public static class PaginateQueryAsync
    {
        public static async Task<PaginationResponse<T>> PaginateAsync<T>(this IQueryable<T> query, int page, int size)
        {
            page = (page <= 0) ? 0 : page;
            size = (size <= 0) ? 10 : size;

            var totalItems = await query.CountAsync();

            var items = await query.Skip(page * size).Take(size).ToListAsync();

            return new PaginationResponse<T>(items, totalItems, page, size);
        }
    }
}
