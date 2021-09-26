using System;
using System.Collections.Generic;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Boilerplate.Api.IntegrationTests.Helpers
{
    public static class Utilities
    {
        private static void InitializeDbForTests(AppDbContext db)
        {
            db.Movies.AddRange(GetSeedingMovies());
            db.SaveChanges();
        }

        private static void ReinitializeDbForTests(AppDbContext db)
        {
            db.Movies.RemoveRange(db.Movies);
            InitializeDbForTests(db);
        }

        private static IEnumerable<MovieEntity> GetSeedingMovies()
        {
            return new List<MovieEntity>
            {
                new() { Id = Guid.NewGuid(), Title = "Silence of the Lambdas", DisplayStart = DateTime.UtcNow.AddDays(-1), DisplayEnd = DateTime.UtcNow.AddDays(1)},
                new() { Id = Guid.NewGuid(), Title = "Get Out", DisplayStart = DateTime.UtcNow.AddDays(-1), DisplayEnd = DateTime.UtcNow.AddDays(1)},
                new() { Id = Guid.NewGuid(), Title = "Something Something Test", DisplayStart = DateTime.UtcNow.AddDays(-1), DisplayEnd = DateTime.UtcNow.AddDays(1)},
            };
        }

        public static WebApplicationFactory<Startup> BuildApplicationFactory(this WebApplicationFactory<Startup> factory)
        {
            return factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Testing");
                builder.ConfigureServices(services =>
                {
                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<AppDbContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();

                        db.Database.EnsureCreated();

                        try
                        {
                            InitializeDbForTests(db);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding the " +
                                                "database with test messages. Error: {Message}", ex.Message);
                        }
                    }
                });
            });
        }


        public static WebApplicationFactory<Startup> RebuildDb(this WebApplicationFactory<Startup> factory)
        {
            return factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices
                            .GetRequiredService<AppDbContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<IntegrationTest>>();
                        try
                        {
                            ReinitializeDbForTests(db);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding " +
                                                "the database with test messages. Error: {Message}",
                                ex.Message);
                        }
                    }
                });
            });
        }
    }
}
