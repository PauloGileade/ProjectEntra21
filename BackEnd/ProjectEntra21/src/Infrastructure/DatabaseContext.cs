using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Mappings;

namespace ProjectEntra21.src.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employeer> Employeers { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<CellEmployeer> CellsEmployeers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TotalPartial> TotalPartials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new EmployeerMapping().Initialize(modelBuilder.Entity<Employeer>());
            new CellMapping().Initialize(modelBuilder.Entity<Cell>());
            new CellEmployeerMapping().Initialize(modelBuilder.Entity<CellEmployeer>());
            new ProductMapping().Initialize(modelBuilder.Entity<Product>());
            new OrderMapping().Initialize(modelBuilder.Entity<Order>());
            new TotalPartialMapping().Initialize(modelBuilder.Entity<TotalPartial>());
        }
    }
}
