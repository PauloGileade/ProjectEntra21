using Microsoft.EntityFrameworkCore;
using ProjectEntra21.Domain.Entiteis;

namespace ProjectEntra21.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employeer> Employeers { get; set; }
    }
}
