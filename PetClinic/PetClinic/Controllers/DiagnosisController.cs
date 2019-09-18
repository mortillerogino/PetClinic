using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Services.Interfaces;

namespace PetClinic.Controllers
{
    [Authorize(Roles = "Veterinarian")]
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosisService _service;
        private readonly ILogger _logger;

        public DiagnosisController(IDiagnosisService service, ILogger<DiagnosisController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DiagnosisDto dto)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var newDiag = await _service.AddAsync(dto, userId);
            return Ok(newDiag);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var diagnoses = await _service.GetAsync(id);
            return Ok(diagnoses);
        }
    }
}