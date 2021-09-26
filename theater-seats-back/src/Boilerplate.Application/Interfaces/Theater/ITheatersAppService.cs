using System;
using System.Threading.Tasks;
using Boilerplate.Application.DTOs.Theater;

namespace Boilerplate.Application.Interfaces.Theater
{
    public interface ITheatersAppService
    {
        public Task<TheaterGetDto> GetById(Guid theaterId);
    }
}