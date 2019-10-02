using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services.Interfaces;

namespace PetClinic.Data.Services
{
    public class VeterinarianService : IVeterinarianService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VeterinarianService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Veterinarian> AddAsync(Veterinarian vet)
        {
            await _unitOfWork.VeterinarianRepository.InsertAsync(vet);

            await _unitOfWork.CommitAsync();

            return vet;
        }


        public async Task<IEnumerable<Veterinarian>> GetAsync()
        {
            await _unitOfWork.SpecializationRepository.GetAsync(null, null, s => s.MedicalField);
            return await _unitOfWork.VeterinarianRepository.GetAsync(null, null, v => v.Specializations);
        }

        public async Task<IEnumerable<VeterinarianDto>> GetAsDtoAsync()
        {
            var vets = await GetAsync();
            List<VeterinarianDto> vetDtos = new List<VeterinarianDto>();

            // TO DO: Map Veterinarian to dto
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
            //var dto = new VeterinarianDto
            //{
            //    Id = veterinarian.Id,
            //    Name = veterinarian.Name
            //};
            var dto = _mapper.Map<VeterinarianDto>(veterinarian);
            var specs = new List<string>();

            foreach (Specialization spec in veterinarian.Specializations)
            {
                specs.Add(spec.MedicalField.Name);
            }

            dto.Specializations = specs;

            return dto;
        }
    }
}
