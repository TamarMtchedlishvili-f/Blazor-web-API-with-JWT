using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IraoAssignment.Server.Data;
using IraoAssignment.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace IraoAssignment.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).Build();

            //2. Find the service layer within our scope.
            using var scope = host.Services.CreateScope();

            //3. Get the instance of BoardGamesDBContext in our services layer
            var services = scope.ServiceProvider;
            // var context = services.GetRequiredService<BoardGamesDBContext>();
            try
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await UserAndRoleDataInitializer.SeedData(userManager, roleManager);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            //4. Call the DataGenerator to create sample data
            //DataGenerator.Initialize(services);

            host.Run();
        }
    }
}