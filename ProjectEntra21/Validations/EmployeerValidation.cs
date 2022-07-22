using Microsoft.EntityFrameworkCore;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure;
using ProjectEntra21.Infrastructure.Database.Common;
using ProjectEntra21.Infrastructure.Database.Repositories;
using System.Linq;

namespace ProjectEntra21.Validations
{
    public class EmployeerValidation
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<Employeer> Dbset;
        public long ValidationRegister()
        {
            var newRegister = Context.Employeers.OrderByDescending(x => x.Register).First();
            return newRegister.Register ++;
        }
    }
}
