using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Services.Interfaces
{
    public interface IDiagnosisService
    {
        Task<Diagnosis> AddAsync(DiagnosisDto dto, string vetUserId);

        Task<IEnumerable<Diagnosis>> GetAsync(Guid patientId);
    }
}
