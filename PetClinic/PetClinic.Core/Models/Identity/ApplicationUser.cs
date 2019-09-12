using Microsoft.AspNetCore.Identity;
using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Core.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Patient> Patient { get; set; }
    }
}
