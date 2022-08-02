using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            return Insert(cellEmployeer);
        }

        public bool ValidationCodeCell(int? codeCell)
        {
            var cell = Context.Cells.Where(x => x.CodeCell == codeCell).Select(x => x.CodeCell).FirstOrDefault();

            if (codeCell == 0 || cell == 0)

                return false;


            return true;
        }

        public bool ValidationRegisterEmployeer(long? registerEmployyer)
        {
            var cell = Context.Employeers.Where(x => x.Register == registerEmployyer).Select(x => x.Register).FirstOrDefault();

            if (registerEmployyer == 0 || cell == 0)

                return false;


            return true;
        }
    }
}
