using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;

namespace PetClinic.Controllers
{
    [Authorize(Roles = "Veterinarian")]
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> Post(DiagnosisDto dto)
        //{
        //    var newDiagnosis = new Diagnosis
        //    {
        //        Notes = dto.Notes,
        //        PatientId = dto.PatientId,
        //        VeterinarianId = dto.VeterinarianId
        //    };


        //}
    }
}