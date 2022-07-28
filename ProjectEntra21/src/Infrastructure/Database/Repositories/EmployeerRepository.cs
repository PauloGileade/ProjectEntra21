using Microsoft.EntityFrameworkCore;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;
using ProjectEntra21.src.Application.Database;
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
            var nextRegister = NextRegisterEmployeer();
            employeer.Register = nextRegister;

            await Dbset.AddAsync(employeer);
            await Context.SaveChangesAsync();

        }

        public new async Task Update(Employeer employeer)
        {
            if (ValidationCodeCell(employeer.CodeCell))
            {
                Context.Entry(employeer).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IList<Employeer>> SelectMore()
        {
            return await Dbset.ToListAsync();
        }

        public async Task<Employeer> SelectOne(long register)
        {
            return await Dbset.FindAsync(register);
        }

        public async Task Delete(long register)
        {
            var deleteEmployeer = await Dbset.FindAsync(register);
            Dbset.Remove(deleteEmployeer);
            await Context.SaveChangesAsync();
        }

        public long NextRegisterEmployeer()
        {
            var newRegister = Context.Employeers.Select(x => x.Register).OrderByDescending(x => x).FirstOrDefault();

            return newRegister + 1;
        }

        public bool ValidationCodeCell(int? cells)
        {
            var cell = Context.Cells.Where(x => x.CodeCell == cells).Select(x => x.CodeCell).FirstOrDefault();

            if (cells == 0 || cell == 0)

                return false;


            return true;
        }
    }
}
