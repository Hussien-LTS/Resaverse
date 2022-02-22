using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIControllres.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenity _amenityService;

        public AmenityController(IAmenity amenity)
        {
            _amenityService = amenity;
        }

        [HttpPost]
        public async Task<ActionResult<AmenityDTO>> Create([FromBody] AmenityDTO amenity)
        {
            try
            {
                await _amenityService.Create(amenity);
                return CreatedAtAction("GetAmenity", new { amenityId = amenity.Id }, amenity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); ;
            }

        }

        [HttpGet]
        public async Task<ActionResult<JSONRes<AmenitiesDTO>>> GetAmenites()
        {
            try
            {
                var results = await _amenityService.GetAmenites();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet("{amenityId}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity([FromRoute] int amenityId)
        {
            try
            {
                var result = await _amenityService.GetAmenity(amenityId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AmenityDTO>> UpdateFloorAsync([FromRoute] int id, [FromBody] AmenityDTO amenity)
        {
            try
            {
                var updatedRecord = await _amenityService.UpdateAmenity(id, amenity);
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
                await _amenityService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

    }
}
