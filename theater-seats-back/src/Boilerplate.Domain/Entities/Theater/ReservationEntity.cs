using Boilerplate.Domain.Core.Entities;

namespace Boilerplate.Domain.Entities.Theater
{
    public class ReservationEntity : Entity
    {
        public TimeSlotEntity TimeSlot { get; set; }
        
        public string Name { get; set; }
        
        public int Row { get; set; }
        
        public int Column { get; set; }
    }
}