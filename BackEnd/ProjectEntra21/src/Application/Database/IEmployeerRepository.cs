using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;

namespace ProjectEntra21.src.Application.Database
{
    public interface IEmployeerRepository : IBaseRepository<Employeer>
    {
        public long NextRegisterEmployeer();
    }
}
