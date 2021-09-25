using System;

namespace Boilerplate.Application.DTOs.Theater
{
    public class TimeSlotGetDto
    {
        public Guid Id { get; set; }
        
        public DateTime DateTime { get; set; }
    }
}