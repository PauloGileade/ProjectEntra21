using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure;
using ProjectEntra21.Infrastructure.Database.Common;
using ProjectEntra21.Infrastructure.Database.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntra21.Validations
{
    public static class EmployeerValidation
    {

        public static long ValidationRegister(DatabaseContext context)
        {
            var newRegister = context.Employeers.Select(x => x.Register).OrderByDescending(x => x).FirstOrDefault();

            return newRegister + 1;
        }

        public static bool ValidationCodeCell(DatabaseContext context, int? cells)
        {
            var cell = context.Cells.Where(x => x.CodeCell == cells).Select(x => x.CodeCell).FirstOrDefault();

            if (cells == 0 || cell == 0)

                return false;


            return true;
        }
    }
}
