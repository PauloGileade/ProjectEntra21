using Microsoft.EntityFrameworkCore;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectEntra21.Infrastructure.Database.Repositories
{
    public class CellEmployeerRepository : BaseRepository<CellEmployeer>, ICellEmployeerRepository
    {
        public CellEmployeerRepository(DatabaseContext context) : base(context)
        {
        }

        public new async Task Insert(CellEmployeer cellEmployeer)
        {
            Context.Add(cellEmployeer);
            await Context.SaveChangesAsync();
        }

        public new async Task Update(CellEmployeer cellEmployeer)
        {
            Context.Entry(cellEmployeer).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task<IList<CellEmployeer>> SelectMore()
        {
            return await Dbset.ToArrayAsync();
        }
        
        public async Task<CellEmployeer> SelectOne(long id)
        {
            return await Dbset.FindAsync(id);
        }

        public async Task Delete(long id)
        {
            var deleteCellEmployeer = await Dbset.FindAsync(id);
            Dbset.Remove(deleteCellEmployeer);
            await Context.SaveChangesAsync();
        }
    }
}
