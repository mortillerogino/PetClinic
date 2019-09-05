using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services.Interfaces;

namespace PetClinic.Data.Services
{
    public class VeterinarianService : IVeterinarianService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VeterinarianService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Veterinarian> AddAsync(Veterinarian vet)
        {
            vet.Id = Guid.NewGuid();
            _unitOfWork.VeterinarianRepository.Insert(vet);

            await _unitOfWork.CommitAsync();

            return vet;
        }


        public IEnumerable<Veterinarian> Get()
        {
            _unitOfWork.SpecializationRepository.Get(null, null, s => s.Field);
            return _unitOfWork.VeterinarianRepository.Get(null, null, v => v.Specializations);
        }

        public IEnumerable<VeterinarianDto> GetAsDto()
        {
            var vets = Get();
            List<VeterinarianDto> vetDtos = new List<VeterinarianDto>();

            foreach (Veterinarian v in vets)
            {
                vetDtos.Add(ConvertToDto(v));
            }

            return vetDtos;
        }

        public int GetCount()
        {
            return _unitOfWork.VeterinarianRepository.GetCount();
        }

        private VeterinarianDto ConvertToDto(Veterinarian veterinarian)
        {
            var dto = new VeterinarianDto
            {
                Id = veterinarian.Id,
                Name = veterinarian.Name
            };

            var specs = new List<string>();

            foreach (Specialization spec in veterinarian.Specializations)
            {
                specs.Add(spec.Field.Name);
            }

            dto.Specializations = specs;

            return dto;
        }
    }
}
