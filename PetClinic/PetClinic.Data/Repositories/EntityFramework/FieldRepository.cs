using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        public FieldRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
