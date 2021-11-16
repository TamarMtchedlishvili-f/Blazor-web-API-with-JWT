using IraoAssignment.Shared;
using Microsoft.EntityFrameworkCore;

namespace IraoAssignment.Server.Data
{
    public class IraoAssignmentDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Market>().HasData(
                new Market
                {
                    Id = 1,
                    MarketName = "Market1"
                }
            );
        }

        public IraoAssignmentDbContext(DbContextOptions<IraoAssignmentDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Market> Markets { get; set; }
    }
}