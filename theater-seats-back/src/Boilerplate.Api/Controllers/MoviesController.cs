using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Application.DTOs.Hero;
using Boilerplate.Application.DTOs.Theater;
using Boilerplate.Application.Interfaces.Theater;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("Policy")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesAppService _moviesAppService;
        
        public MoviesController(IMoviesAppService moviesAppService)
        {
            _moviesAppService = moviesAppService;
        }

        /// <summary>
        /// Returns all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<MovieGetDto>>> Get()
        {
            return Ok(await _moviesAppService.GetAll());
        }

        /// <summary>
        /// Creates a movie
        /// </summary>
        /// <param name="movieInsertDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<TimeSlotGetDto>>> Post([FromBody] MovieInsertDto movieInsertDto)
        {
            var newTimeSlot = await _moviesAppService.Create(movieInsertDto);
            return CreatedAtAction(nameof(GetById), new { id = newTimeSlot.Id }, newTimeSlot);
        }


        /// <summary>
        /// Get one movie by id from the database
        /// </summary>
        /// <param name="id">The movie's id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(GetHeroDto), 200)]
        public async Task<ActionResult<GetHeroDto>> GetById(Guid id)
        {
            var timeSlot = await _moviesAppService.GetById(id);
            if (timeSlot == null) return NotFound();
            return Ok(timeSlot);
        }
    }
}