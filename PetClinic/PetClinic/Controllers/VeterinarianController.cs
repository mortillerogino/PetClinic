using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Services.Interfaces;

namespace PetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarianController : ControllerBase
    {
        private readonly IVeterinarianService _vetService;

        public VeterinarianController(IVeterinarianService veterinarianService)
        {
            _vetService = veterinarianService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<VeterinarianDto> vets = _vetService.GetAsDto();

            return Ok(vets);
        }
    }
}