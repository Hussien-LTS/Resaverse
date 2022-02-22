using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
/// check the datetime
namespace APIControllres.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservation _reservationService;

        public ReservationController(IReservation reservation)
        {
            _reservationService = reservation;
        }

        [HttpPost]
        [Route("{userId}/reserve/{roomId}")]
        public async Task<ActionResult<ReservationDTO>> Create([FromBody] ReservationDTO reservation, int roomId, string userId)
        {
            try
            {
                var createdRecord = await _reservationService.Create(reservation, roomId, userId);
                return CreatedAtAction("GetReservation", new { roomId = roomId }, reservation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); ;
            }

        }

        [HttpGet]
        public async Task<ActionResult<JSONRes<ReservationsDTO>>> GetReservations()
        {
            try
            {
                var results = await _reservationService.GetReservations();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPost]
        [Route("room/{roomId}")]
        public async Task<ActionResult<ReservationDTO>> GetReservation([FromRoute] int roomId, [FromBody] DateTime startTime)
        {
            try
            {
                var result = await _reservationService.GetReservation(roomId, startTime);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<ActionResult<JSONRes<ReservationsByUserDTO>>> GetReservationsForUser([FromRoute] string userId)
        {
            try
            {
                var results = await _reservationService.GetReservationsForUser(userId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        [Route("update/{userId}/reserve/{roomId}/{startTime}")]
        public async Task<ActionResult<ReservationDTO>> UpdateReservation(int roomId, string userId, DateTime startTime, ReservationDTO reservation)
        {
            try
            {
                var updatedRecord = await _reservationService.UpdateReservation(roomId,userId, startTime, reservation);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpDelete("{roomId}")]
        public async Task<IActionResult> Delete([FromRoute] int roomId, [FromBody] DateTime startTime)
        {
            try
            {
                await _reservationService.Delete(roomId, startTime);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

    }
}