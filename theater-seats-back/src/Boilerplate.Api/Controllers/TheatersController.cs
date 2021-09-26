using System;
using System.Threading.Tasks;
using Boilerplate.Application.DTOs.Theater;
using Boilerplate.Application.Interfaces.Theater;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("Policy")]
    public class TheatersController : ControllerBase
    {
        private readonly ITheatersAppService _theatersAppService;
        public TheatersController(ITheatersAppService theatersAppService)
        {
            _theatersAppService = theatersAppService;
        }


        /// <summary>
        /// Get one movie by id from the database
        /// </summary>
        /// <param name="theaterId">The movie's id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{theaterId:guid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(TheaterGetDto), 200)]
        public async Task<ActionResult<TheaterGetDto>> GetById([FromQuery] Guid theaterId)
        {
            var theater = await _theatersAppService.GetById(theaterId);
            if (theater == null) return NotFound();
            return Ok(theater);
        }
    }
}