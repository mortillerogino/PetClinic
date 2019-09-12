using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetClinic.Core.Models;
using PetClinic.Core.Models.Identity;
using PetClinic.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.Data.Seed
{
    public class DummySeeder
    {
        private readonly IServiceProvider _services;
        private ApplicationUser seededUser;

        public DummySeeder(IServiceProvider services)
        {
            _services = services;
        }

        public async Task SeedUser()
        {
            string seededUserName = "Seeded User";
            string seededPassword = "1234";

            var userManager = _services.GetService<UserManager<ApplicationUser>>();
            seededUser = await userManager.FindByNameAsync(seededUserName);

            if (seededUser != null)
            {
                return;
            }

            seededUser = new ApplicationUser
            {
                UserName = seededUserName,
                Email = "seeded@seeder.com"
            };

            await userManager.CreateAsync(seededUser, seededPassword);

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
                    new Patient { Name = "Tutu", User = seededUser },
                    new Patient { Name = "Fifi", User = seededUser },
                    new Patient { Name = "Brownie", User = seededUser },
                    new Patient { Name = "Biter", User = seededUser },
                    new Patient { Name = "Rush", User = seededUser },
                    new Patient { Name = "Treble", User = seededUser },
                    new Patient { Name = "Lassie", User = seededUser },
                    new Patient { Name = "Bolt", User = seededUser },
                    new Patient { Name = "Brownie", User = seededUser },
                    new Patient { Name = "Beethoven", User = seededUser },
                    new Patient { Name = "Hooch", User = seededUser },
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
