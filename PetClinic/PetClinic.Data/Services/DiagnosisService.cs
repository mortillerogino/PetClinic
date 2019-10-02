using AutoMapper;
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
        private readonly IMapper _mapper;

        public DiagnosisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Diagnosis> AddAsync(DiagnosisDto dto, string vetUserId)
        {
            var vetUser = await _unitOfWork.UserRepository.GetByIdAsync(vetUserId);

            // TO DO: convert with automapper dto to diagnosis
            //var newDiag = new Diagnosis
            //{
            //    Notes = dto.Notes,
            //    VeterinarianId = vetUser.VeterinarianId.Value,
            //    PatientId = dto.PatientId,
            //    Date = DateTime.Now
            //};

            var newDiag = _mapper.Map<Diagnosis>(dto);
            newDiag.VeterinarianId = vetUser.VeterinarianId.Value;
            newDiag.Date = DateTime.Now;
         
            await _unitOfWork.DiagnosisRepository.InsertAsync(newDiag);
            await _unitOfWork.CommitAsync();

            return newDiag;
        }

        public async Task<IEnumerable<DiagnosisDto>> GetAsync(Guid patientId)
        {
            var diagnoses = await _unitOfWork.DiagnosisRepository.GetAsync(d => d.PatientId == patientId, null, d => d.Veterinarian);
            var retVal = new List<DiagnosisDto>();

            if (diagnoses.Count == 0)
            {
                return retVal;
            }

            foreach (var item in diagnoses)
            {
                //// TO DO: convert with automapper, diagnosis to dto
                //retVal.Add(new DiagnosisDto
                //{
                //    Notes = item.Notes,
                //    Date = item.Date,
                //    VeterinarianName = item.Veterinarian.Name
                //});
                retVal.Add(_mapper.Map<DiagnosisDto>(item));
            }

            return retVal;
        }


    }
}
