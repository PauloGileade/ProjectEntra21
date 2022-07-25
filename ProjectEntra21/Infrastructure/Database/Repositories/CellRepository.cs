﻿using Microsoft.EntityFrameworkCore;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.Infrastructure.Database.Repositories
{
    public class CellRepository : BaseRepository<Cell>, ICellRepository
    {
        public CellRepository(DatabaseContext context) : base(context)
        {
        }

        public new async Task Insert(Cell cell)
        {
            Context.Add(cell);
            await Context.SaveChangesAsync();
        }

        public new async Task Update(Cell cell)
        {
            Context.Entry(cell).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public new Task InsertOrUpdate(Cell cell)
        {
            if (Dbset.Any(x => x.CodeCell == cell.CodeCell))

                return Update(cell);


            return Insert(cell);
        }

        public async Task<IList<Cell>> SelectMore()
        {
            return await Dbset.ToListAsync();
        }

        public async Task<Cell> SelectOne(int code)
        {
            return await Dbset.FindAsync(code);
        }

        public async Task Delete(int code)
        {
            var deleteCell = await Dbset.FindAsync(code);
            Dbset.Remove(deleteCell);
            await Context.SaveChangesAsync();
        }
    }
}
