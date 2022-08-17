using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using ProjectEntra21.src.Infrastructure.Database.Common.Extension;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Infrastructure.Database.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        public new Task InsertOrUpdate(Order order)
        {
            if (Dbset.Any(x => x.Code == order.Code))

                return Update(order);


            order.Code = NextCodeOrder();
            return Insert(order);
        }

        public long NextCodeOrder()
        {
            var newCode = Context.Orders.Select(x => x.Code).OrderByDescending(x => x).FirstOrDefault();

            return newCode + 1;
        }

        public async Task<PaginationResponse<Order>> SelectAll(long register, DateTime date, FilterBase filters)
        {
            return await Dbset.Where(x => x.CellEmployeer.Employeer.Register == register
           && x.CreateAt >= date.Date.Date && x.CreateAt < date.Date.AddDays(1))
               .Include(x => x.Product)
               .Include(x => x.CellEmployeer.Cell)
               .Include(x => x.CellEmployeer.Employeer)
               .AsNoTracking()
               .PaginateAsync(filters._page, filters._size);
        }

        public override async Task<Order> SelectOne(Expression<Func<Order, bool>> filter = null)
        {
            return await Dbset.Where(filter)
                .Include(x => x.Product)
                .Include(x => x.CellEmployeer.Cell)
                .Include(x => x.CellEmployeer.Employeer)
                .FirstOrDefaultAsync();
        }
    }
}
