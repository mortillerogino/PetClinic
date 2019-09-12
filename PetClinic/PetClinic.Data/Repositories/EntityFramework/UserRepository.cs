using Microsoft.EntityFrameworkCore;
using PetClinic.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
