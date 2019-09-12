using PetClinic.Core.DTO;
using PetClinic.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.Data.Services.Interfaces
{
    public interface IVeterinarianService
    {
        int GetCount();
        Task<Veterinarian> AddAsync(Veterinarian vet);
        Task<IEnumerable<Veterinarian>> GetAsync();
        Task<IEnumerable<VeterinarianDto>> GetAsDtoAsync();

    }
}
