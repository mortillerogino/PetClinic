using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DbContext dbContext) 
            :base(dbContext)
        {

        }

        public async Task<int> GetCountAsync()
        {
            return await _dbSet.CountAsync();
        }
    }
}
