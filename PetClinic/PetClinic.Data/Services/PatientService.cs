using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> Get()
        {
            return _unitOfWork.PatientsRepository.Get();
        }

        public Patient GetById(Guid id)
        {
            return _unitOfWork.PatientsRepository.GetById(id);
        }
    }
}
