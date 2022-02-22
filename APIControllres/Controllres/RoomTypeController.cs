using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIControllres.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomType _RoomTypeService;

        public RoomTypeController(IRoomType roomType)
        {
            _RoomTypeService = roomType;
        }

        [HttpPost]
        public async Task<ActionResult<RoomTypesDTO>> Create([FromBody] RoomTypesDTO roomType)
        {
            try
            {
                var createdRecord = await _RoomTypeService.Create(roomType);
                return CreatedAtAction("GetRoomType", new { roomTypeId = roomType.Id }, roomType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); ;
            }

        }
 
        [HttpGet]
        public async Task<ActionResult<JSONRes<RoomTypesDTO>>> GetRoomTypes()
        {
            try
            {
                var results = await _RoomTypeService.GetRoomTypes();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet("{roomTypeId}")]
        public async Task<ActionResult<RoomTypeDTO>> GetRoomType([FromRoute] int roomTypeId)
        {
            try
            {
                var result = await _RoomTypeService.GetRoomsByType(roomTypeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoomTypesDTO>> UpdateRoomTypeAsync([FromRoute] int id, [FromBody] RoomTypesDTO roomType)
        {
            try
            {
                var updatedRecord = await _RoomTypeService.UpdateRoomType(id, roomType);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _RoomTypeService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

    }
}
