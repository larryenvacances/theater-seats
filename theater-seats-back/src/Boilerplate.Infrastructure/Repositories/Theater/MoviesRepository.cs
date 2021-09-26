using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Domain.Repositories.Theater;
using Boilerplate.Infrastructure.Context;

namespace Boilerplate.Infrastructure.Repositories.Theater
{
    public class MoviesRepository : Repository<MovieEntity>, IMoviesRepository
    {
        public MoviesRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}