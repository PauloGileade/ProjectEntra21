using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using ProjectEntra21.src.Infrastructure.Database.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Infrastructure.Database.Repositories
{
    public class TotalPartialRepository : BaseRepository<TotalPartial>, ITotalPartialRepository
    {
        public TotalPartialRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<TotalPartial> SelectTotalPartial(int phase, long product)
        {
            var enumPharse = Enum.Parse<PhaseCell>(phase.ToString());

            return await Dbset.Where(x => x.Phase == enumPharse && x.Product.Code == product)
                .Include(x => x.Cell)
                .Include(x => x.Product)
                .FirstOrDefaultAsync();
        }

        public async Task<TotalPartial> SelectTotalPartialByPhase(PhaseCell phase, long codeCell)
        {
            return await Dbset.Where(x => x.Phase == phase && x.Cell.CodeCell == codeCell)
                .Include(x => x.Cell)
                .Include(x => x.Product)
                .FirstOrDefaultAsync();
        }
    }
}
