using Microsoft.Extensions.DependencyInjection;
using PetClinic.Core.Models;
using PetClinic.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.Data.Seed
{
    public class DummySeeder
    {
        private readonly IServiceProvider _services;

        public DummySeeder(IServiceProvider services)
        {
            _services = services;
        }

        public async Task SeedDummyPatients()
        {
            var patientService = _services.GetRequiredService<IPatientService>();

            var patientsCount = patientService.GetCount();
            if (patientsCount > 0)
            {
                return;
            }
            else
            {
                var patients = new Patient[]
                {
                    new Patient { Name = "Tutu" },
                    new Patient { Name = "Fifi" },
                    new Patient { Name = "Brownie" },
                };

                await patientService.AddMultipleAsync(patients);

            }

        }

        public async Task SeedDummyVets()
        {
            var specService = _services.GetRequiredService<ISpecializationService>();
            var vetService = _services.GetRequiredService<IVeterinarianService>();
            var fieldService = _services.GetRequiredService<IFieldService>();

            bool seeded = vetService.GetCount() > 0;

            if (seeded)
            {
                return;
            }

            var generalHeathField = await fieldService.AddAsync(new Field { Name = "General Health" });
            var surgeryField = await fieldService.AddAsync(new Field { Name = "Surgery" });

            var vetMichael = await vetService.AddAsync(new Veterinarian { Name = "Michael Brown" });
            var vetLiza = await vetService.AddAsync(new Veterinarian { Name = "Liza Gomez" });

            await specService.AddAsync(vetMichael, generalHeathField);
            await specService.AddAsync(vetMichael, surgeryField);
            await specService.AddAsync(vetLiza, surgeryField);



        }


    }
}
