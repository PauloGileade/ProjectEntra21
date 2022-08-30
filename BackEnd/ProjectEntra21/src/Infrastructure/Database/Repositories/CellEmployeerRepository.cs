using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using ProjectEntra21.src.Infrastructure.Database.Common.Extension;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Infrastructure.Database.Repositories
{
    public class CellEmployeerRepository : BaseRepository<CellEmployeer>, ICellEmployeerRepository
    {
        public CellEmployeerRepository(DatabaseContext context) : base(context)
        {
        }

        public new Task InsertOrUpdate(CellEmployeer cellEmployeer)
        {
            if (Dbset.Any(x => x.Code == cellEmployeer.Code))

                return Update(cellEmployeer);

            var countInsert = Context.CellsEmployeers.Where(x => x.CreateAt >= DateTime.Now.Date
                    && x.CreateAt < DateTime.Now.Date.AddDays(1) && x.Cell.CodeCell == cellEmployeer.Cell.CodeCell).Count();

            if (countInsert < 6)
            {
                cellEmployeer.Code = NextCode();
                return Insert(cellEmployeer);
            }

            return Task.CompletedTask;
        }

        public long NextCode()
        {
            var newRegister = Context.CellsEmployeers.Select(x => x.Code).OrderByDescending(x => x).FirstOrDefault();

            return newRegister + 1;
        }

        public override async Task<PaginationResponse<CellEmployeer>> SelectAll(FilterBase filters)
        {
            return await Dbset
                .Include(x => x.Cell)
                .Include(x => x.Employeer)
                .AsTracking()
                .PaginateAsync(filters._page, filters._size);
        }

        public async Task<PaginationResponse<CellEmployeer>> SelectMore(long codeCell, DateTime date, FilterBase filters)
        {
            return await Dbset.Where(x => x.Cell.CodeCell == codeCell
            && x.CreateAt >= date.Date.Date && x.CreateAt < date.Date.AddDays(1))
                .Include(x => x.Cell)
                .Include(x => x.Employeer)
                .AsNoTracking()
                .PaginateAsync(filters._page, filters._size);
        }
    }
}
