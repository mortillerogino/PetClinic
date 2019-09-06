using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Utilities;

namespace PetClinic.Data.Services.Interfaces
{
    public interface IPatientService
    {
        int GetCount();
        Task<Patient> AddAsync(PatientDto patientDto);

        Task AddMultipleAsync(IEnumerable<Patient> patients);
        Task<PaginatedList<Patient>> GetPaginatedListAsync(string searchString = null, string sortOrder = null, int pageIndex = 1, int pageSize = 10);
        Patient GetById(Guid id);
        Task<Patient> RemoveAsync(Guid id);
        Task<Patient> UpdateAsync(Guid id, PatientDto patientDto);
    }
}