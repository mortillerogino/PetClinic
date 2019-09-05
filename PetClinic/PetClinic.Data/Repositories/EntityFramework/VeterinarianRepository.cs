using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class VeterinarianRepository : Repository<Veterinarian>, IVeterinarianRepository
    {
        public VeterinarianRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
