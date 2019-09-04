using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;

namespace PetClinic.Data.Services
{
    public interface IPatientService
    {
        Task<Patient> AddAsync(PatientDto patientDto);
        IEnumerable<Patient> Get();
        Patient GetById(Guid id);
        Task<Patient> RemoveAsync(Guid id);
        Task<Patient> UpdateAsync(Guid id, PatientDto patientDto);
    }
}