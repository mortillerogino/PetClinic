using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services;
using PetClinic.DTO;

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
        public IActionResult Get()
        {
            IEnumerable<Patient> patients = _patientService.Get();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var patient = _patientService.GetById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        //[HttpPost]
        //public IActionResult Post(PatientDTO patientDTO)
        //{
        //    if (patientDTO != null)
        //    {

        //    }
        //}

    }
}