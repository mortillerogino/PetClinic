using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class DiagnosisRepository : Repository<Diagnosis>, IDiagnosisRepository
    {
        public DiagnosisRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
