using System;
using Boilerplate.Domain.Core.Entities;

namespace Boilerplate.Domain.Entities.Theater
{
    public class ReservationEntity : Entity
    {
        public TimeSlotEntity TimeSlot { get; set; }

        public Guid TimeSlotId { get; set; }

        public Guid TheaterEntityId { get; set; }

        public string Name { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}