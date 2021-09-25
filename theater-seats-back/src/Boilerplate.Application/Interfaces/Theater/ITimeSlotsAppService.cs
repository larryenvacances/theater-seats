using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Application.DTOs.Theater;

namespace Boilerplate.Application.Interfaces.Theater
{
    public interface ITimeSlotsAppService : IDisposable
    {
        public Task<IEnumerable<TimeSlotGetDto>> GetAll(Guid movieId);
        
        public Task<TimeSlotGetDto> Create(TimeSlotInsertDto timeSlotInsertDto);
        
        public Task<TimeSlotGetDto> GetById(Guid id);
    }
}