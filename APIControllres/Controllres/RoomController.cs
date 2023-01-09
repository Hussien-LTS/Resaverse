using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIControllres.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IRoom _RoomService;
        public RoomController(IRoom room)
        {
            _RoomService = room;
        }
        //****************************************************************************************************** Create
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> Create([FromBody] RoomDTO room)
        {
            try
            {
                var createdRecord = await _RoomService.Create(room);
                return CreatedAtAction("GetRoom", new { roomId = room.Id }, room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); ;
            }
        }
        //****************************************************************************************************** GetRooms
        [HttpGet]
        public async Task<ActionResult<JSONRes<RoomsDTO>>> GetRooms()
        {
            try
            {
                var results = await _RoomService.GetRooms();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //****************************************************************************************************** GetRoom
        [HttpGet("{roomId}")]
        public async Task<ActionResult<RoomDTO>> GetRoom([FromRoute] int roomId)
        {
            try
            {
                var result = await _RoomService.GetRoom(roomId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //****************************************************************************************************** GetRoomsByFloor
        [HttpGet]
        [Route("RoomsByFloor/{floorId}")]
        public async Task<ActionResult<RoomDTO>> GetRoomsByFloor([FromRoute] int floorId)
        {
            try
            {
                var result = await _RoomService.GetRoomsByFloor(floorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //****************************************************************************************************** UpdateRoom
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomDTO>> UpdateRoom([FromRoute] int id, [FromBody] RoomDTO room)
        {
            try
            {
                var updatedRecord = await _RoomService.UpdateRoom(id, room);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //****************************************************************************************************** Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _RoomService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
