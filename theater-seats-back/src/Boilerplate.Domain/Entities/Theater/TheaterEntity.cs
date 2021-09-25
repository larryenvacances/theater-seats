using System.Collections.Generic;
using Boilerplate.Domain.Core.Entities;

namespace Boilerplate.Domain.Entities.Theater
{
    public class TheaterEntity : Entity
    {
        public List<ReservationEntity> Reservations { get; set; }
        
        public int Rows { get; set; }
        
        public int Columns { get; set; }
    }
}