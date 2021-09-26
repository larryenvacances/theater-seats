using System;

namespace Boilerplate.Application.DTOs.Theater
{
    public class ReservationInsertDto
    {
        public Guid TimeSlotId { get; set; }
        
        public Guid TheaterEntityId { get; set; }
        
        public string Name { get; set; }
        
        public int Row { get; set; }
        
        public int Column { get; set; }
    }
}