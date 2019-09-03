using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Models
{
    public class PetClinicContext : DbContext
    {
        public PetClinicContext(DbContextOptions<PetClinicContext> options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
    }
}
