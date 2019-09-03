using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.Models;
using PetClinic.Data.Repositories;

namespace PetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Patient> patients = _unitOfWork.PatientsRepository.Get();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var patient = _unitOfWork.PatientsRepository.GetById(id);

            return Ok(patient);
        }

    }
}