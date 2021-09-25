using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Application.DTOs.Theater;

namespace Boilerplate.Application.Interfaces.Theater
{
    public interface IMoviesAppService : IDisposable
    {
        public Task<IEnumerable<MovieGetDto>> GetAll();

        public Task<MovieGetDto> Create(MovieInsertDto movieInsertDto);

        public Task<MovieGetDto> GetById(Guid movieId);
    }
}