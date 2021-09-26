using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Boilerplate.Application.DTOs.Theater;
using Boilerplate.Application.Interfaces.Theater;
using Boilerplate.Domain.Entities.Theater;
using Boilerplate.Domain.Repositories.Theater;

namespace Boilerplate.Application.Services.Theater
{
    public class ReservationsAppService : IReservationsAppService
    {
        private readonly IMapper _mapper;
        private readonly IReservationsRepository _reservationsRepository;

        public ReservationsAppService(IReservationsRepository reservationsRepository, IMapper mapper)
        {
            _reservationsRepository = reservationsRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<ReservationGetDto>> Create(List<ReservationInsertDto> reservationInsertDtos)
        {
            var newReservations =
                _reservationsRepository.CreateMany(_mapper.Map<List<ReservationEntity>>(reservationInsertDtos));
            await _reservationsRepository.SaveChangesAsync();
            return _mapper.Map<List<ReservationGetDto>>(newReservations);
        }
    }
}