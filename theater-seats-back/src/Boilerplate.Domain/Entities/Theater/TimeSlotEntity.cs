using System;
using Boilerplate.Domain.Core.Entities;

namespace Boilerplate.Domain.Entities.Theater
{
    public class TimeSlotEntity : Entity
    {
        public Guid MovieEntityId { get; set; }

        public int DisplayHour { get; set; }

        public TheaterEntity Theater { get; set; }
    }
}