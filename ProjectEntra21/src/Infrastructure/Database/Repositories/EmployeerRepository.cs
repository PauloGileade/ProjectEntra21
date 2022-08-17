using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Infrastructure.Database.Repositories
{
    public class EmployeerRepository : BaseRepository<Employeer>, IEmployeerRepository
    {
        public EmployeerRepository(DatabaseContext context) : base(context)
        {
        }

        public new Task InsertOrUpdate(Employeer employeer)
        {
            if (Dbset.Any(x => x.Register == employeer.Register))

                return Update(employeer);


            employeer.Register = NextRegisterEmployeer();
            return Insert(employeer);
        }
        public long NextRegisterEmployeer()
        {
            var newRegister = Context.Employeers.Select(x => x.Register).OrderByDescending(x => x).FirstOrDefault();

            return newRegister + 1;
        }
    }
}
