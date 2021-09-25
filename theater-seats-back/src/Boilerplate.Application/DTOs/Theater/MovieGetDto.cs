using System;
using System.Collections.Generic;

namespace Boilerplate.Application.DTOs.Theater
{
    public class MovieGetDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public List<TimeSlotGetDto> TimeSlots { get; set; }
    }
}