using System;
using System.Threading.Tasks;
using Boilerplate.Api.Extensions;
using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Domain.Repositories.Theater;
using Boilerplate.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Boilerplate.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = SerilogExtension.CreateLogger();
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                Log.Logger.Information("Application starting up...");
                var dbContext = services.GetRequiredService<AppDbContext>();
                if (dbContext.Database.IsSqlServer()) await dbContext.Database.MigrateAsync();
                await dbContext.Database.EnsureCreatedAsync();
                await SeedDatabase(dbContext);
                await host.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "Application startup failed.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static async Task SeedDatabase(AppDbContext dbContext)
        {
            if ((await dbContext.Movies.FirstOrDefaultAsync(x =>
                x.Title == "Silence of the Lambdas")) is null)
            {
                Log.Logger.Information("Seeding database...");

                var movie = dbContext.Movies.Add(new MovieEntity
                {
                    Id = Guid.NewGuid(),
                    Title = "Silence of the Lambdas",
                    DisplayStart = DateTime.UtcNow.AddDays(-10),
                    DisplayEnd = DateTime.UtcNow.AddDays(10)
                }).Entity;

                var theater1 = dbContext.Theaters.Add(new TheaterEntity
                {
                    Id = Guid.NewGuid(),
                    Columns = 8,
                    Rows = 5
                }).Entity;
                
                var theater2 = dbContext.Theaters.Add(new TheaterEntity
                {
                    Id = Guid.NewGuid(),
                    Columns = 8,
                    Rows = 5
                }).Entity;
                
                var theater3 = dbContext.Theaters.Add(new TheaterEntity
                {
                    Id = Guid.NewGuid(),
                    Columns = 8,
                    Rows = 5
                }).Entity;
                
                var theater4 = dbContext.Theaters.Add(new TheaterEntity
                {
                    Id = Guid.NewGuid(),
                    Columns = 8,
                    Rows = 5
                }).Entity;

                dbContext.TimeSlots.Add(new TimeSlotEntity
                {
                    Id = Guid.NewGuid(),
                    Theater = theater1,
                    DisplayHour = 10,
                    MovieEntityId = movie.Id
                });

                dbContext.TimeSlots.Add(new TimeSlotEntity
                {
                    Id = Guid.NewGuid(),
                    Theater = theater2,
                    DisplayHour = 14,
                    MovieEntityId = movie.Id
                });

                dbContext.TimeSlots.Add(new TimeSlotEntity
                {
                    Id = Guid.NewGuid(),
                    Theater = theater3,
                    DisplayHour = 18,
                    MovieEntityId = movie.Id
                });

                dbContext.TimeSlots.Add(new TimeSlotEntity
                {
                    Id = Guid.NewGuid(),
                    Theater = theater4,
                    DisplayHour = 22,
                    MovieEntityId = movie.Id
                });

                await dbContext.SaveChangesAsync();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}