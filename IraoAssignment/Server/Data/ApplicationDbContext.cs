using IraoAssignment.Shared;
using Microsoft.EntityFrameworkCore;

namespace IraoAssignment.Server.Data
{
     public class ApplicationDbContext : DbContext
      {
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
          {
          }
          public DbSet<Company> Companies { get; set; }
          public DbSet<Market> Markets { get; set; }
      }
}