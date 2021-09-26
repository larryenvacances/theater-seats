using System.Collections.Generic;
using System.Linq;
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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsAppService _reservationsAppService;

        public ReservationsController(IReservationsAppService reservationsAppService)
        {
            _reservationsAppService = reservationsAppService;
        }

        /// <summary>
        ///     Creates a reservation
        /// </summary>
        /// <param name="reservationInsertDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<List<ReservationGetDto>>> Put(
            [FromBody] List<ReservationInsertDto> reservationInsertDto)
        {
            var newReservations = await _reservationsAppService.Create(reservationInsertDto);
            return CreatedAtAction(nameof(Put), new {ids = newReservations.Select(x => x.Id)}, newReservations);
        }
    }
}