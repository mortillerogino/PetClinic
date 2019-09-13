using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models;
using PetClinic.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Models
{
    public class PetClinicContext : IdentityDbContext<ApplicationUser,
        IdentityRole,
        string,
        ApplicationUserClaim,
        IdentityUserRole<string>,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {
        public PetClinicContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<MedicalField> MedicalFields { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserClaim> ApplicationUserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Veterinarian>().ToTable("Veterinarian");
            modelBuilder.Entity<Diagnosis>().ToTable("Diagnosis");
            modelBuilder.Entity<Specialization>().ToTable("Specialization");
            modelBuilder.Entity<MedicalField>().ToTable("MedicalField");
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("ApplicationUserClaim");
        }
    }
}
