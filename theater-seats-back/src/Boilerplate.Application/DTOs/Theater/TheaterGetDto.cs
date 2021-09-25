using System;
using System.Collections.Generic;

namespace Boilerplate.Application.DTOs.Theater
{
    public class TheaterGetDto
    {
        public Guid Id { get; set; }
        
        public List<ReservationGetDto> Reservations { get; set; }
        
        public int Rows { get; set; }
        
        public int Columns { get; set; }
    }
}