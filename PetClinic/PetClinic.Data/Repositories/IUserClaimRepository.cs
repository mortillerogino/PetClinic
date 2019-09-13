using PetClinic.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories
{
    public interface IUserClaimRepository : IRepository<ApplicationUserClaim>
    {
    }
}
