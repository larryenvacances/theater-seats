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
    public class MoviesAppService : IMoviesAppService
    {
        private readonly IMapper _mapper;
        private readonly IMoviesRepository _moviesRepository;

        public MoviesAppService(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<MovieGetDto>> GetAll(DateTime dateTime)
        {
            var movies = await _moviesRepository
                .GetAll()
                .Where(x => x.DisplayStart <= dateTime && dateTime <= x.DisplayEnd)
                .Include(x => x.TimeSlots.OrderBy(y => y.DisplayHour))
                .ThenInclude(x => x.Theater)
                .ToListAsync();

            return _mapper.Map<IEnumerable<MovieGetDto>>(movies);
        }

        public async Task<MovieGetDto> Create(MovieInsertDto movieInsertDto)
        {
            var created = _moviesRepository.Create(_mapper.Map<MovieEntity>(movieInsertDto));
            await _moviesRepository.SaveChangesAsync();
            return _mapper.Map<MovieGetDto>(created);
        }

        public async Task<MovieGetDto> GetById(Guid id)
        {
            return _mapper.Map<MovieGetDto>(await _moviesRepository.GetById(id));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _moviesRepository.Dispose();
        }
    }
}