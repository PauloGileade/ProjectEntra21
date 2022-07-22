using Microsoft.EntityFrameworkCore;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Mappings;

namespace ProjectEntra21.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employeer> Employeers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new EmployeerMapping().Initialize(modelBuilder.Entity<Employeer>());
        }
    }
}
