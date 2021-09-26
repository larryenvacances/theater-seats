using System;
using System.Collections.Generic;
using Boilerplate.Domain.Core.Entities;

namespace Boilerplate.Domain.Entities.Theater
{
    public class MovieEntity : Entity
    {
        public string Title { get; set; }

        public List<TimeSlotEntity> TimeSlots { get; set; }

        public DateTime DisplayStart { get; set; }

        public DateTime DisplayEnd { get; set; }
    }
}