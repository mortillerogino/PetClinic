using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using PetClinic.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Models
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientDto, Patient>();
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
                

            CreateMap<Veterinarian, VeterinarianDto>()
                .ReverseMap();

            CreateMap<PaginatedList<Patient>, PaginatedPatientsDto>()
                .ReverseMap();

            CreateMap<Diagnosis, DiagnosisDto>()
                .ForMember(dest => dest.VeterinarianName, opt => opt.MapFrom(src => src.Veterinarian.Name));

            CreateMap<DiagnosisDto, Diagnosis>()
                .ForMember(dest => dest.Veterinarian, act => act.Ignore());
        }
    }
}
