using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using IraoAssignment.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IraoAssignment.Server.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new IraoAssignmentDbContext(serviceProvider.GetRequiredService<DbContextOptions<IraoAssignmentDbContext>>());

            if (DynamicQueryableExtensions.Any(context.Markets)) return;
            context.Markets.AddRange(new Market
                {
                    Id = 1,
                    MarketName = "Market1"
                },
                new Market
                {
                    Id = 2,
                    MarketName = "Market2"
                },
                new Market
                {
                    Id = 3,
                    MarketName = "Market3"
                }
            );

            if (DynamicQueryableExtensions.Any(context.Companies)) return;
            context.Companies.AddRange(
                new Company
                {
                    Id = 1,
                    CompanyName = "Company1"
                },
                new Company
                {
                    Id = 2,
                    CompanyName = "Company2"
                },
                new Company
                {
                    Id = 3,
                    CompanyName = "Company3"
                },
                new Company
                {
                    Id = 4,
                    CompanyName = "Company4"
                },
                new Company
                {
                    Id = 5,
                    CompanyName = "Company5"
                }
            );
            
            context.SaveChanges();

            if (DynamicQueryableExtensions.Any(context.MarketWithCompanyAndPrices)) return;
            context.MarketWithCompanyAndPrices.AddRange(
                new MarketWithCompanyAndPrice
                {
                    Id = 1,
                    Company = context.Companies.Single(c => c.Id == 1),
                    Market = context.Markets.Single(m => m.Id == 1),
                    CompanyPrice = 200
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 2,
                    Company = context.Companies.Single(c => c.Id == 2),
                    Market = context.Markets.Single(m => m.Id == 1)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 3,
                    Company = context.Companies.Single(c => c.Id == 3),
                    Market = context.Markets.Single(m => m.Id == 1)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 4,
                    Company = context.Companies.Single(c => c.Id == 4),
                    Market = context.Markets.Single(m => m.Id == 1)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 5,
                    Company = context.Companies.Single(c => c.Id == 5),
                    Market = context.Markets.Single(m => m.Id == 1)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 6,
                    Company = context.Companies.Single(c => c.Id == 1),
                    Market = context.Markets.Single(m => m.Id == 2)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 7,
                    Company = context.Companies.Single(c => c.Id == 2),
                    Market = context.Markets.Single(m => m.Id == 2)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 8,
                    Company = context.Companies.Single(c => c.Id == 3),
                    Market = context.Markets.Single(m => m.Id == 2)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 9,
                    Company = context.Companies.Single(c => c.Id == 4),
                    Market = context.Markets.Single(m => m.Id == 2)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 10,
                    Company = context.Companies.Single(c => c.Id == 5),
                    Market = context.Markets.Single(m => m.Id == 2)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 11,
                    Company = context.Companies.Single(c => c.Id == 1),
                    Market = context.Markets.Single(m => m.Id == 3)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 12,
                    Company = context.Companies.Single(c => c.Id == 2),
                    Market = context.Markets.Single(m => m.Id == 3)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 13,
                    Company = context.Companies.Single(c => c.Id == 3),
                    Market = context.Markets.Single(m => m.Id == 3)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 14,
                    Company = context.Companies.Single(c => c.Id == 4),
                    Market = context.Markets.Single(m => m.Id == 3)
                },
                new MarketWithCompanyAndPrice
                {
                    Id = 15,
                    Company = context.Companies.Single(c => c.Id == 5),
                    Market = context.Markets.Single(m => m.Id == 3)
                }


            );


            context.SaveChanges();
        }
    }

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
            // SaveChanges();
        }

        public IraoAssignmentDbContext(DbContextOptions<IraoAssignmentDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketWithCompanyAndPrice> MarketWithCompanyAndPrices { get; set; }
    }
}