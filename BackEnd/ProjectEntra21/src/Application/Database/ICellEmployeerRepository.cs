using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Database
{
    public interface ICellEmployeerRepository : IBaseRepository<CellEmployeer>
    {
        public long NextCode();
        public Task<PaginationResponse<CellEmployeer>> SelectMore(long codeCell, DateTime date, FilterBase filters);
        public Task<CellEmployeer> SelectOneEmployeer(long resgister);
    }
}
