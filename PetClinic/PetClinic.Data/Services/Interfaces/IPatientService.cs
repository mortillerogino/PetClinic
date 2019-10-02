using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Utilities;

namespace PetClinic.Data.Services.Interfaces
{
    public interface IPatientService
    {
        int GetCount();
        Task<Patient> AddAsync(PatientDto patientDto, string userId);

        Task AddMultipleAsync(IEnumerable<Patient> patients);
        Task<PaginatedList<Patient>> GetPaginatedListAsync(string searchString = null, 
            string sortOrder = null, 
            int pageIndex = 1, 
            int pageSize = 10, params Expression<Func<Patient, object>>[] includes);

        Task<PaginatedPatientsDto> GetPaginatedListDtoAsync(string searchString = null,
            string sortOrder = null,
            int pageIndex = 1,
            int pageSize = 10);

        Task<Patient> GetByIdAsync(Guid id);
        Task<Patient> RemoveAsync(Guid id);
        Task<Patient> UpdateAsync(Guid id, PatientDto patientDto);
    }
}