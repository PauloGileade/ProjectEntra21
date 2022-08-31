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
        public Task<PaginationResponse<Order>> SelectAllByRegister(long registerEmployeer, DateTime dateStart, DateTime dateEnd, FilterBase filters);
        public Task<PaginationResponse<Order>> SelectAllByCodecell(long codeCell, DateTime date, FilterBase filters);
        public Task<PaginationResponse<Order>> SelectAllOrder(FilterBase filters);
    }
}
