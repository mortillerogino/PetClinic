using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetClinic.Core.DTO;
using PetClinic.Data.Services.Interfaces;

namespace PetClinic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarianController : ControllerBase
    {
        private readonly IVeterinarianService _vetService;
        private readonly ILogger<VeterinarianController> _logger;

        public VeterinarianController(IVeterinarianService veterinarianService, ILogger<VeterinarianController> logger)
        {
            _vetService = veterinarianService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<VeterinarianDto> vets = await _vetService.GetAsDtoAsync();
            if (vets == null)
            {
                return NotFound();
            }

            

            return Ok(vets);
        }
    }
}