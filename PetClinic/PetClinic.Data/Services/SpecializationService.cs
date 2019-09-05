using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpecializationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Specialization> AddAsync(Veterinarian vet, Field field)
        {
            var newSpec = new Specialization
            {
                Veterinarian = vet,
                Field = field
            };

            _unitOfWork.SpecializationRepository.Insert(newSpec);

            await _unitOfWork.CommitAsync();

            return newSpec;
        }
    }
}
