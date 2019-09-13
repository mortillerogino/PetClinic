using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Services.Interfaces;

namespace PetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string searchString = null, string sortOrder = null, int pageIndex = 1, int pageSize = 10)
        {
            var patients = await _patientService.GetPaginatedListAsync(searchString, sortOrder, pageIndex, pageSize);

            var patientsDto = new PaginatedPatientsDto
            {
                HasPreviousPage = patients.HasPreviousPage,
                HasNextPage = patients.HasNextPage,
                Patients = patients
            };

            return Ok(patientsDto);
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
            //var a = User.I;

            try
            {
                var patient = await _patientService.AddAsync(patientDTO);

                return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
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