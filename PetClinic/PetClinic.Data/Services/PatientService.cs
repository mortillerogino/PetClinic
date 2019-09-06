using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                DateAdded = DateTime.UtcNow
            };

            _unitOfWork.PatientsRepository.Insert(newPatient);
            await _unitOfWork.CommitAsync();
            return newPatient;
        }

        public IEnumerable<Patient> Get(string searchString = null, string sortOrder = null)
        {
            List<Patient> patients;
            Expression<Func<Patient, bool>> searchFunction = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchFunction = a => a.Name == searchString;
            }

            patients = _unitOfWork.PatientsRepository.Get(searchFunction);

            return patients;
        }

        public Patient GetById(Guid id)
        {
            return _unitOfWork.PatientsRepository.GetById(id);
        }

        public int GetCount()
        {
            return _unitOfWork.PatientsRepository.GetCount();
        }

        public async Task<Patient> RemoveAsync(Guid id)
        {
            var patient = _unitOfWork.PatientsRepository.GetById(id);
            _unitOfWork.PatientsRepository.Delete(id);
            await _unitOfWork.CommitAsync();

            return patient;
        }

        public async Task<Patient> UpdateAsync(Guid id, PatientDto patientDto)
        {
            var editedPatient = _unitOfWork.PatientsRepository.GetById(id);
            editedPatient.Name = patientDto.Name;

            _unitOfWork.PatientsRepository.Update(editedPatient);
            await _unitOfWork.CommitAsync();

            return editedPatient;
        }

        public async Task AddMultipleAsync(IEnumerable<Patient> patients)
        {
            foreach (Patient p in patients)
            {
                p.Id = Guid.NewGuid();
                p.DateAdded = DateTime.UtcNow;
                _unitOfWork.PatientsRepository.Insert(p);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
