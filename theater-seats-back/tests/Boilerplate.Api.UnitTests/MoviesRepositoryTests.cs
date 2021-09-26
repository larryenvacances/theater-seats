using System;
using System.Threading.Tasks;
using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Infrastructure.Context;
using Boilerplate.Infrastructure.Repositories.Theater;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Boilerplate.Api.UnitTests
{
    public class MoviesRepositoryTests
    {
        private static AppDbContext CreateDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(name)
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task It_ReturnsMovie_WhenMovieExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            await using (var context = CreateDbContext("GetMovies"))
            {
                context.Set<MovieEntity>().Add(new MovieEntity {Id = id});
                await context.SaveChangesAsync();
            }

            MovieEntity movie = null;

            // Act
            await using (var context = CreateDbContext("GetMovies"))
            {
                var repository = new MoviesRepository(context);
                movie = await repository.GetById(id);
            }

            // Assert
            movie.Should().NotBeNull();
            movie.Id.Should().Be(id);
        }

        [Fact]
        public async Task It_ReturnsNull_WhenMovieDoesntExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            await using (var context = CreateDbContext("GetMovies_Null"))
            {
                context.Set<MovieEntity>().Add(new MovieEntity {Id = id});
                await context.SaveChangesAsync();
            }

            MovieEntity hero;

            // Act
            await using (var context = CreateDbContext("GetMovies_Null"))
            {
                var repository = new MoviesRepository(context);
                hero = await repository.GetById(Guid.NewGuid());
            }

            // Assert
            hero.Should().BeNull();
        }
    }
}