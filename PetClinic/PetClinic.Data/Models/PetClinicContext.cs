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
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Field> Fields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Veterinarian>().ToTable("Veterinarian");
            modelBuilder.Entity<Diagnosis>().ToTable("Diagnosis");
            modelBuilder.Entity<Specialization>().ToTable("Specialization");
            modelBuilder.Entity<Field>().ToTable("Field");
        }
    }
}
