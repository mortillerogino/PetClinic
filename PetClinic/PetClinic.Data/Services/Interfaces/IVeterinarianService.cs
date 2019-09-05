using PetClinic.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.Data.Services.Interfaces
{
    public interface IVeterinarianService
    {
        Task AddMultipleAsync(IEnumerable<Veterinarian> vets);
    }
}
