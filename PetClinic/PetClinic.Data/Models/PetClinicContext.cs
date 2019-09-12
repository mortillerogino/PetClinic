using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClinic.Core.Models;
using PetClinic.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Models
{
    public class PetClinicContext : IdentityDbContext<ApplicationUser>
    {
        public PetClinicContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Veterinarian>().ToTable("Veterinarian");
            modelBuilder.Entity<Diagnosis>().ToTable("Diagnosis");
            modelBuilder.Entity<Specialization>().ToTable("Specialization");
            modelBuilder.Entity<Field>().ToTable("Field");
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
        }
    }
}
