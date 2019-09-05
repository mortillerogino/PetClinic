using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class SpecializationRepository : Repository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
