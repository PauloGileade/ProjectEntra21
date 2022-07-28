using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;

namespace ProjectEntra21.src.Application.Database
{
    public interface IEmployeerRepository : IBaseRepository<Employeer>
    {
        public long NextRegisterEmployeer();
        public bool ValidationCodeCell(int? cells);
    }
}
