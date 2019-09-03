using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<int> GetCountAsync();
    }
}
