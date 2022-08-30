using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Database
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public long NextCodeOrder();
        public Task<PaginationResponse<Order>> SelectAll(long registerEmployeer, DateTime date, FilterBase filters);
    }
}
