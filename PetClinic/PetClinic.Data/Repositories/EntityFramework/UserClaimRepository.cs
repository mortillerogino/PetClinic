using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class UserClaimRepository : Repository<ApplicationUserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
