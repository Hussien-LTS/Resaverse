using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIControllres.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloor _floorService;

        public FloorController( IFloor floor)
        {
            _floorService = floor;
        }
        [HttpGet]
        public async Task<ActionResult<JSONRes<FloorsDTO>>> GetFloors()
        {
            var results = await _floorService.GetFloors();
            return Ok(results);
        }
    }
}
