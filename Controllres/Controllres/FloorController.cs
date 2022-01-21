using CoreModels.Data;
using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllres.Controllres
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

        // GET: api/Floors
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        public async Task<ActionResult<JSONRes<FloorsDTO>>> GetFloors()
        {
            var list= await _floorService.GetFloors();
            return Ok(list);
        }

    }
}
