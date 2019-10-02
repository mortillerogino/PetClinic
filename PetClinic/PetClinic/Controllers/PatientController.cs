using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Services.Interfaces;

namespace PetClinic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger _logger;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string searchString = null, string sortOrder = null, int pageIndex = 1, int pageSize = 10)
        {
            var patients = await _patientService.GetPaginatedListDtoAsync(searchString, sortOrder, pageIndex, pageSize);

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);

        }

        [HttpPost]
        public async Task<IActionResult> Post(PatientDto patientDTO)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (userId == null)
            {
                return BadRequest();
            }

            var patient = await _patientService.AddAsync(patientDTO, userId);

            return CreatedAtAction(nameof(Get), new { name = patient.Name });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var patient = await _patientService.RemoveAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PatientDto patientDto)
        {
            var patient = await _patientService.UpdateAsync(id, patientDto);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }


    }
}