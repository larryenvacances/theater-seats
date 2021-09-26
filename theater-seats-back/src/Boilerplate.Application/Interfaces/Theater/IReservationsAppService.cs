using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Application.DTOs.Theater;

namespace Boilerplate.Application.Interfaces.Theater
{
    public interface IReservationsAppService : IDisposable
    {
        public Task<List<ReservationGetDto>> Create(List<ReservationInsertDto> movieInsertDto);
    }
}