using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;

namespace ProjectEntra21.src.Application.Database
{
    public interface ICellRepository : IBaseRepository<Cell>
    {
        public long NextCodeCell();
    }
}
