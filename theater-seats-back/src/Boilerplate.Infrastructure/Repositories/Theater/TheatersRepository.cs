using Boilerplate.Domain.Core.Interfaces;
using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Domain.Repositories.Theater;
using Boilerplate.Infrastructure.Context;

namespace Boilerplate.Infrastructure.Repositories.Theater
{
    public class TheatersRepository : Repository<TheaterEntity>, ITheatersRepository
    {
        public TheatersRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}