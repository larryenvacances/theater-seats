using System.Collections.Generic;
using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Domain.Repositories.Theater;
using Boilerplate.Infrastructure.Context;

namespace Boilerplate.Infrastructure.Repositories.Theater
{
    public class ReservationsRepository : Repository<ReservationEntity>, IReservationsRepository
    {
        public ReservationsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public List<ReservationEntity> CreateMany(List<ReservationEntity> reservationEntities)
        {
            DbSet.AddRange(reservationEntities);
            return reservationEntities;
        }
    }
}