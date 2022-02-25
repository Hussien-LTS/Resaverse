using CoreModels.Data;
using CoreModels.Models;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class AccountService : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ResaverseDbContext _dbContext;

        public AccountService
            (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
        ResaverseDbContext dbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _dbContext = dbContext;
        }
        //*************************************************************************************** Register
        public async Task<IdentityResult> Register(RegisterModel registerModel)
        {
            //if (registerModel == null) return BadRequest("Model Null");
            //if (!ModelState.IsValid) return BadRequest("Not Valid");
            //if (IsEmailExist(registerModel.Email))
            //    return StatusCode(StatusCodes.Status400BadRequest, "Email Is Already Used");
            //if (IsUserNameExist(model.UserName))
            //    return StatusCode(StatusCodes.Status400BadRequest, "User Name Is Already Used");
            var user = new ApplicationUser()
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email,
                UserName = registerModel.Email
            };
            return await _userManager.CreateAsync(user, registerModel.Password);
        }
        //*************************************************************************************** Login
        public async Task<string> LogIn(LogInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
