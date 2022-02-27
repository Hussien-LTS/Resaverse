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
    public class AccountController : ControllerBase
    {
        private readonly IAccount _applicationUser;
        public AccountController(IAccount applicationUser)
        {
            _applicationUser = applicationUser;
        }
        //*************************************************************************************** Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                if (registerModel == null) return BadRequest("Model Null");
                //if (!ModelState.IsValid) return BadRequest("Not Valid");
                var result = await _applicationUser.Register(registerModel, this.ModelState);
                if (ModelState.IsValid)
                {
                    return result;
                }
                return BadRequest(new ValidationProblemDetails(ModelState));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //*************************************************************************************** Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LogInModel signInModel)
        {
            try
            {
                var result = await _applicationUser.LogIn(signInModel);
                if (!string.IsNullOrEmpty(result))
                {
                    return Ok(result);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
