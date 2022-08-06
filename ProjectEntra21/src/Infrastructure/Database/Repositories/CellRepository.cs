using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Infrastructure.Database.Repositories
{
    public class CellRepository : BaseRepository<Cell>, ICellRepository
    {
        public CellRepository(DatabaseContext context) : base(context)
        {
        }

        public new Task InsertOrUpdate(Cell cell)
        {
            if (Dbset.Any(x => x.CodeCell == cell.CodeCell))

                return Update(cell);


            cell.CodeCell = NextCodeCell();
            return Insert(cell);
        }

        public long NextCodeCell()
        {
            var newRegister = Context.Cells.Select(x => x.CodeCell).OrderByDescending(x => x).FirstOrDefault();

            return newRegister + 1;
        }
    }
}
