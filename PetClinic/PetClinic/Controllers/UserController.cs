using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetClinic.Core.DTO;
using PetClinic.Core.Models.Identity;
using PetClinic.Models;
using PetClinic.Security;

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
            var user = await _userManager.FindByNameAsync(dto.UserName);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, dto.Password))
                {
                    var userTokenHandler = new UserTokenHandler(user, _userManager, _appSettings);
                    var token = await userTokenHandler.CreateUserToken();
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


    }
}