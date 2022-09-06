using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Database
{
    public interface ITotalPartialRepository : IBaseRepository<TotalPartial>
    {
        public Task<TotalPartial> SelectTotalPartial(int phase, long product);
    }
}
