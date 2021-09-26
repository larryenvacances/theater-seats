using System.Collections.Generic;
using Boilerplate.Domain.Core.Interfaces;
using Boilerplate.Domain.Entities.Theater;

namespace Boilerplate.Domain.Repositories.Theater
{
    public interface IReservationsRepository : IRepository<ReservationEntity>
    {
        public List<ReservationEntity> CreateMany(List<ReservationEntity> reservationEntities);
    }
}