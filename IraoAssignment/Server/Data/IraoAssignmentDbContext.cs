﻿using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Duende.IdentityServer.EntityFramework.Options;
using IraoAssignment.Server.Models;
using IraoAssignment.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IraoAssignment.Server.Data
{
    public static class UserAndRoleDataInitializer
    {
        public static async Task SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }

        private static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var johnDoeEmail = "johndoe@localhost.com";
            if (await userManager.FindByEmailAsync(johnDoeEmail) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = johnDoeEmail,
                    Email = johnDoeEmail,
                    EmailConfirmed = true
                };
                //user.FirstName = "John";
                //user.LastName = "Doe";

                var result = await userManager.CreateAsync(user, "P@ssw0rd1!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Admin);
                }
            }
        }

        private const string Admin = nameof(Admin);

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.RoleExistsAsync(Admin)) return;

            var role = new IdentityRole { Name = Admin };
            await roleManager.CreateAsync(role);
        }
    }

    //public static class DataGenerator
    //{
    //    public static void Initialize(IServiceProvider serviceProvider)
    //    {
    //        using var context = new IraoAssignmentDbContext(serviceProvider.GetRequiredService<DbContextOptions<IraoAssignmentDbContext>>(),
    //            new OptionsWrapper<OperationalStoreOptions>(new OperationalStoreOptions()));

    //        if (DynamicQueryableExtensions.Any(context.Markets)) return;
    //        context.Markets.AddRange(new Market
    //        {
    //            Id = 1,
    //            MarketName = "Market1"
    //        },
    //            new Market
    //            {
    //                Id = 2,
    //                MarketName = "Market2"
    //            },
    //            new Market
    //            {
    //                Id = 3,
    //                MarketName = "Market3"
    //            }
    //        );

    //        if (DynamicQueryableExtensions.Any(context.Companies)) return;
    //        context.Companies.AddRange(
    //            new Company
    //            {
    //                Id = 1,
    //                CompanyName = "Company1"
    //            },
    //            new Company
    //            {
    //                Id = 2,
    //                CompanyName = "Company2"
    //            },
    //            new Company
    //            {
    //                Id = 3,
    //                CompanyName = "Company3"
    //            },
    //            new Company
    //            {
    //                Id = 4,
    //                CompanyName = "Company4"
    //            },
    //            new Company
    //            {
    //                Id = 5,
    //                CompanyName = "Company5"
    //            }
    //        );

    //        context.SaveChanges();

    //        if (DynamicQueryableExtensions.Any(context.MarketWithCompanyAndPrices)) return;

    //        MarketWithCompanyAndPrice GenerateFor(int id, int companyId, int marketId)
    //            => new MarketWithCompanyAndPrice
    //            {
    //                Id = id,
    //                Company = context.Companies.Single(c => c.Id == companyId),
    //                Market = context.Markets.Single(m => m.Id == marketId),
    //                CompanyPrice = new Random().Next(10, 30)
    //            };

    //        var range = Enumerable.Range(1, 5) // companies
    //            .SelectMany(companyId => Enumerable.Range(1, 3) // markets
    //                .Select(marketId => (companyId, marketId)))
    //            .Select((marketCompanyId, index) => (marketCompanyId.marketId, marketCompanyId.companyId, index: index + 1))
    //            .ToList();

    //        context.MarketWithCompanyAndPrices.AddRange(
    //            range
    //                .Select(rng => GenerateFor(rng.index, rng.companyId, rng.marketId)).ToList());

    //        context.SaveChanges();
    //    }
    //}

    public class IraoAssignmentDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public IraoAssignmentDbContext(DbContextOptions<IraoAssignmentDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketWithCompanyAndPrice> MarketWithCompanyAndPrices { get; set; }


    }

    //public class AiRagaca : IDesignTimeDbContextFactory<IraoAssignmentDbContext>
    //{
    //    public IraoAssignmentDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<IraoAssignmentDbContext>();
    //        optionsBuilder.UseSqlServer();
    //        var optionalStorageOptions = new StorageOptions

    //        return IraoAssignmentDbContext(optionsBuilder.Options)
    //    }
    //}
}