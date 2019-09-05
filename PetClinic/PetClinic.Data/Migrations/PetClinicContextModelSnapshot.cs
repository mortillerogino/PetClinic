﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetClinic.Data.Models;

namespace PetClinic.Data.Migrations
{
    [DbContext(typeof(PetClinicContext))]
    partial class PetClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetClinic.Core.Models.Diagnosis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Notes");

                    b.Property<Guid>("PatientId");

                    b.Property<Guid>("VeterinarianId");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("VeterinarianId");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("PetClinic.Core.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PetClinic.Core.Models.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("VeterinarianId");

                    b.HasKey("Id");

                    b.HasIndex("VeterinarianId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("PetClinic.Core.Models.Veterinarian", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Veterinarians");
                });

            modelBuilder.Entity("PetClinic.Core.Models.Diagnosis", b =>
                {
                    b.HasOne("PetClinic.Core.Models.Patient", "Patient")
                        .WithMany("Diagnoses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetClinic.Core.Models.Veterinarian", "Veterinarian")
                        .WithMany()
                        .HasForeignKey("VeterinarianId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetClinic.Core.Models.Specialization", b =>
                {
                    b.HasOne("PetClinic.Core.Models.Veterinarian")
                        .WithMany("Specializations")
                        .HasForeignKey("VeterinarianId");
                });
#pragma warning restore 612, 618
        }
    }
}
