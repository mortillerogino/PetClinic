using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PetClinic.Core.DTO;
using PetClinic.Core.Models.Identity;
using PetClinic.Models;

namespace PetClinic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly ILogger _logger;

        public UserController(UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettings, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _appSettings = appSettings;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(dto.UserName);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, dto.Password))
                    {
                        var claims = await _userManager.GetClaimsAsync(user);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.UtcNow.AddMinutes(30),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.Secret)), SecurityAlgorithms.HmacSha256Signature)
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                        var token = tokenHandler.WriteToken(securityToken);
                        return Ok(new { token });
                    }
                    else
                    {
                        string error = "Password is incorrect.";
                        _logger.LogWarning($"Login attempt by user: {dto.UserName} but {error}");
                        return BadRequest(new { Message = error });
                    }
                }
                else
                {
                    string error = "Username does not exist.";
                    _logger.LogWarning($"Login attempt by user: {dto.UserName} but {error}");
                    return BadRequest(new { Message = error });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex);
            }
        }


    }
}