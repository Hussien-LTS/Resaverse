using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIControllres.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloor _floorService;
        public FloorController(IFloor floor)
        {
            _floorService = floor;
        }
        //************************************************************************************************************ Create
        [HttpPost]
        public async Task<ActionResult<FloorDTO>> Create([FromBody] FloorDTO floor)
        {
            try
            {
                var createdRecord = await _floorService.Create(floor);
                return CreatedAtAction("GetFloor", new { floorId = floor.Id }, floor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); ;
            }
        }
        //************************************************************************************************************ GetFloors
        [HttpGet]
        public async Task<ActionResult<JSONRes<FloorsDTO>>> GetFloors()
        {
            try
            {
                var results = await _floorService.GetFloors();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //************************************************************************************************************ GetFloor
        [HttpGet("{floorId}")]
        public async Task<ActionResult<FloorDTO>> GetFloor([FromRoute] int floorId)
        {
            try
            {
                var result = await _floorService.GetFloor(floorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //************************************************************************************************************ UpdateFloor
        [HttpPut("{id}")]
        public async Task<ActionResult<FloorDTO>> UpdateFloor([FromRoute] int id, [FromBody] FloorDTO floor)
        {
            try
            {
                var updatedRecord = await _floorService.UpdateFloor(id, floor);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //************************************************************************************************************ Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _floorService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
