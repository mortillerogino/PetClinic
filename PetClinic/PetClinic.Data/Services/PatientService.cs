using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Patient> AddAsync(PatientDto patientDto)
        {
            var newPatient = new Patient
            {
                Id = Guid.NewGuid(),
                Name = patientDto.Name,
                DateAdded = DateTime.Now
            };

            _unitOfWork.PatientsRepository.Insert(newPatient);
            await _unitOfWork.CommitAsync();
            return newPatient;
        }

        public IEnumerable<Patient> Get()
        {
            return _unitOfWork.PatientsRepository.Get();
        }

        public Patient GetById(Guid id)
        {
            return _unitOfWork.PatientsRepository.GetById(id);
        }

        public async Task<Patient> RemoveAsync(Guid id)
        {
            var patient = _unitOfWork.PatientsRepository.GetById(id);
            _unitOfWork.PatientsRepository.Delete(id);
            await _unitOfWork.CommitAsync();

            return patient;
        }
    }
}
