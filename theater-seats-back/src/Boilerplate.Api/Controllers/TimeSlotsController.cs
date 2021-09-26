using System;
using System.Collections.Generic;
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
    public class TimeSlotsController : ControllerBase
    {
        private readonly ITimeSlotsAppService _timeSlotsAppService;
        
        public TimeSlotsController(ITimeSlotsAppService timeSlotsAppService)
        {
            _timeSlotsAppService = timeSlotsAppService;
        }

        /// <summary>
        /// Returns all timeslots for a movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<TimeSlotGetDto>>> Get([FromQuery] Guid movieId)
        {
            return Ok(await _timeSlotsAppService.GetAll(movieId));
        }

        /// <summary>
        /// Creates a timeslot for a movie
        /// </summary>
        /// <param name="timeSlotInsertDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<TimeSlotGetDto>>> Post([FromBody] TimeSlotInsertDto timeSlotInsertDto)
        {
            var newTimeSlot = await _timeSlotsAppService.Create(timeSlotInsertDto);
            return CreatedAtAction(nameof(GetById), new { id = newTimeSlot.Id }, newTimeSlot);
        }


        /// <summary>
        /// Get one timeSlot by id from the database
        /// </summary>
        /// <param name="id">The timeslot's id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(TimeSlotGetDto), 200)]
        public async Task<ActionResult<TimeSlotGetDto>> GetById(Guid id)
        {
            var timeSlot = await _timeSlotsAppService.GetById(id);
            if (timeSlot == null) return NotFound();
            return Ok(timeSlot);
        }
    }
}