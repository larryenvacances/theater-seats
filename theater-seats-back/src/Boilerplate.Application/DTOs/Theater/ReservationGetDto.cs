using System;

namespace Boilerplate.Application.DTOs.Theater
{
    public class ReservationGetDto
    {
        public Guid Id { get; set; }

        public TimeSlotGetDto TimeSlot { get; set; }

        public string Name { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}