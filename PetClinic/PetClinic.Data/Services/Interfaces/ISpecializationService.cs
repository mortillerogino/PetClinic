using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Services.Interfaces
{
    public interface ISpecializationService
    {
        Task<Specialization> AddAsync(Veterinarian vet, Field field);
    }
}
