using System;

namespace Boilerplate.Application.DTOs.Theater
{
    public class TimeSlotGetDto
    {
        public Guid Id { get; set; }

        public int DisplayHour { get; set; }

        public TheaterGetDto Theater { get; set; }
    }
}