using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Services
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosisService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Diagnosis> AddAsync(DiagnosisDto dto, string vetUserId)
        {
            var vetUser = await _unitOfWork.UserRepository.GetByIdAsync(vetUserId);

            var newDiag = new Diagnosis
            {
                Notes = dto.Notes,
                VeterinarianId = vetUser.VeterinarianId.Value,
                PatientId = dto.PatientId,
                Date = DateTime.Now
            };
         
            await _unitOfWork.DiagnosisRepository.InsertAsync(newDiag);
            await _unitOfWork.CommitAsync();

            return newDiag;
        }

        public async Task<IEnumerable<Diagnosis>> GetAsync()
        {
            return await _unitOfWork.DiagnosisRepository.GetAsync();
        }


    }
}
