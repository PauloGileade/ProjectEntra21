using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.Infrastructure.Database.Repositories
{
    public class EmployeerRepository : BaseRepository<Employeer>, IEmployeerRepository
    {
        public EmployeerRepository(DatabaseContext context) : base(context)
        {
        }

        public new Task InsertOrUpdate(Employeer employeer)
        {
            if(Dbset.Any(x => x.Register == employeer.Register))
            {
                return Update(employeer);
            }

            return Insert(employeer);
        }
    }
}
