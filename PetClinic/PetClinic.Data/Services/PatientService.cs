using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services.Interfaces;
using PetClinic.Data.Utilities;
using PetClinic.Data.Utilities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            await _unitOfWork.PatientsRepository.InsertAsync(newPatient);
            await _unitOfWork.CommitAsync();
            return newPatient;
        }

        public async Task<PaginatedList<Patient>> GetPaginatedListAsync(string searchString = null, 
            string sortOrder = null, 
            int pageIndex = 1, 
            int pageSize = 10, 
            params Expression<Func<Patient, object>>[] includes)
        {
            Expression<Func<Patient, bool>> searchFunction = GetSearchFunction(searchString);
            Func<IQueryable<Patient>, IOrderedQueryable<Patient>> sortFunction = GetSortFunction(sortOrder);


            IQueryable<Patient> patients = _unitOfWork.PatientsRepository.Query(searchFunction, sortFunction, includes);

            return await EfPaginatedList<Patient>.CreateAsync(patients, pageIndex, pageSize);
        }

        private static Expression<Func<Patient, bool>> GetSearchFunction(string searchString = null)
        {
            Expression<Func<Patient, bool>> searchFunction = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchFunction = p => p.Name.Contains(searchString);
            }

            return searchFunction;
        }

        private static Func<IQueryable<Patient>, IOrderedQueryable<Patient>> GetSortFunction(string sortOrder)
        {
            Func<IQueryable<Patient>, IOrderedQueryable<Patient>> sortFunction;
            switch (sortOrder)
            {
                case "patient_desc":
                    sortFunction = p => p.OrderByDescending(patient => patient.Name);
                    break;
                case "date_desc":
                    sortFunction = p => p.OrderByDescending(patient => patient.DateAdded);
                    break;
                case "date_asc":
                    sortFunction = p => p.OrderBy(patient => patient.DateAdded);
                    break;
                default:
                    sortFunction = p => p.OrderBy(patient => patient.Name);
                    break;
            }

            return sortFunction;
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.PatientsRepository.GetByIdAsync(id);
        }

        public int GetCount()
        {
            return _unitOfWork.PatientsRepository.GetCount();
        }

        public async Task<Patient> RemoveAsync(Guid id)
        {
            var patient = await _unitOfWork.PatientsRepository.GetByIdAsync(id);
            await _unitOfWork.PatientsRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            return patient;
        }

        public async Task<Patient> UpdateAsync(Guid id, PatientDto patientDto)
        {
            var editedPatient = await _unitOfWork.PatientsRepository.GetByIdAsync(id);
            editedPatient.Name = patientDto.Name;

            _unitOfWork.PatientsRepository.Update(editedPatient);
            await _unitOfWork.CommitAsync();

            return editedPatient;
        }

        public async Task AddMultipleAsync(IEnumerable<Patient> patients)
        {
            var taskList = new List<Task>();

            foreach (Patient p in patients)
            {
                p.Id = Guid.NewGuid();
                p.DateAdded = DateTime.UtcNow;
                taskList.Add(_unitOfWork.PatientsRepository.InsertAsync(p));
            }

            await Task.WhenAll(taskList);
            await _unitOfWork.CommitAsync();
        }
    }
}
