using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Boilerplate.Application.DTOs.Theater;
using Boilerplate.Application.Interfaces.Theater;
using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Domain.Repositories.Theater;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Application.Services.Theater
{
    public class TimeSlotsAppService : ITimeSlotsAppService
    {
        private readonly IMapper _mapper;
        private readonly ITimeSlotsRepository _timeSlotsRepository;

        public TimeSlotsAppService(ITimeSlotsRepository timeSlotsRepository, IMapper mapper)
        {
            _timeSlotsRepository = timeSlotsRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<TimeSlotGetDto>> GetAll(Guid movieId)
        {
            var timeSlots = await _timeSlotsRepository.GetAll().OrderBy(x => x.DateTime).ToListAsync();

            return _mapper.Map<IEnumerable<TimeSlotGetDto>>(timeSlots);
        }

        public async Task<TimeSlotGetDto> Create(TimeSlotInsertDto timeSlot)
        {
            var created = _timeSlotsRepository.Create(_mapper.Map<TimeSlotEntity>(timeSlot));
            await _timeSlotsRepository.SaveChangesAsync();
            return _mapper.Map<TimeSlotGetDto>(created);
        }

        public async Task<TimeSlotGetDto> GetById(Guid id)
        {
            return _mapper.Map<TimeSlotGetDto>(await _timeSlotsRepository.GetById(id));
        }

        public async Task<TimeSlotGetDto> CreateTimeSlot(TimeSlotInsertDto timeslot)
        {
            var created = _timeSlotsRepository.Create(_mapper.Map<TimeSlotEntity>(timeslot));
            await _timeSlotsRepository.SaveChangesAsync();
            return _mapper.Map<TimeSlotGetDto>(created);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _timeSlotsRepository.Dispose();
        }
    }
}