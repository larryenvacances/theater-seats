using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Domain.Repositories.Theater;
using Boilerplate.Infrastructure.Context;

namespace Boilerplate.Infrastructure.Repositories.Theater
{
    public class TimeSlotsRepository : Repository<TimeSlotEntity>, ITimeSlotsRepository
    {
        public TimeSlotsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}