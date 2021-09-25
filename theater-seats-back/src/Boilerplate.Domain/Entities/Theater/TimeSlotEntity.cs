using System;
using Boilerplate.Domain.Core.Entities;

namespace Boilerplate.Domain.Entities.Theater
{
    public class TimeSlotEntity : Entity
    {
        public DateTime DateTime { get; set; }
        
        public Guid MovieEntityId { get; set; }
    }
}