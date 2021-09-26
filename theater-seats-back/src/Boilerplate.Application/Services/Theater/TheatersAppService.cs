using System;
using System.Threading.Tasks;
using AutoMapper;
using Boilerplate.Application.DTOs.Theater;
using Boilerplate.Application.Interfaces.Theater;
using Boilerplate.Domain.Repositories.Theater;

namespace Boilerplate.Application.Services.Theater
{
    public class TheatersAppService : ITheatersAppService
    {
        private readonly IMapper _mapper;
        private readonly ITheatersRepository _theatersRepository;

        public TheatersAppService(IMapper mapper, ITheatersRepository theatersRepository)
        {
            _mapper = mapper;
            _theatersRepository = theatersRepository;
        }
        
        public async Task<TheaterGetDto> GetById(Guid theaterId)
        {
            return _mapper.Map<TheaterGetDto>(await _theatersRepository.GetById(theaterId));
        }
    }
}