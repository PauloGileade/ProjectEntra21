using Microsoft.EntityFrameworkCore;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;
using ProjectEntra21.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.Infrastructure.Database.Repositories
{
    public class EmployeerRepository : BaseRepository<Employeer>, IEmployeerRepository
    {
        public EmployeerRepository(DatabaseContext context) : base(context)
        {
        }
        public new async Task Insert(Employeer employeer)
        {
            employeer.Register = EmployeerValidation.ValidationRegister(Context);
            if (EmployeerValidation.ValidationCodeCell(Context, employeer.CodeCell))
            {
                Context.Add(employeer);
                await Context.SaveChangesAsync();
            }
        }

        public new async Task Update(Employeer employeer)
        {
            Context.Entry(employeer).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public new Task InsertOrUpdate(Employeer employeer)
        {
            if (Dbset.Any(x => x.Register == employeer.Register))

                return Update(employeer);


            return Insert(employeer);
        }

        public async Task<IList<Employeer>> SelectMore()
        {
            return await Dbset.ToListAsync();
        }

        public async Task<Employeer> SelectOne(long id)
        {
            return await Dbset.FindAsync(id);
        }

        public async Task Delete(long id)
        {
            var deleteEmployeer = await Dbset.FindAsync(id);
            Dbset.Remove(deleteEmployeer);
            await Context.SaveChangesAsync();
        }
    }
}
