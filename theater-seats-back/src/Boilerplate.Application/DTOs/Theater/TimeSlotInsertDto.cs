using System;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.DTOs.Theater
{
    public class TimeSlotInsertDto
    {
        [Required] public Guid MovieEntityId { get; set; }

        public int DisplayHour { get; set; }
    }
}