using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System.Linq;
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
    }
}
