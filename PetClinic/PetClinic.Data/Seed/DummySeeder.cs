using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetClinic.Core.Models;
using PetClinic.Core.Models.Identity;
using PetClinic.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetClinic.Data.Seed
{
    public class DummySeeder
    {
        private readonly IServiceProvider _services;
        private ApplicationUser _seededUser;

        public DummySeeder(IServiceProvider services)
        {
            _services = services;
        }

        public async Task SeedUser()
        {
            string seededUserName = "admin";
            string seededPassword = "1234";

            var userManager = _services.GetService<UserManager<ApplicationUser>>();
            _seededUser = await userManager.FindByNameAsync(seededUserName);

            

            if (_seededUser != null)
            {
                return;
            }

            _seededUser = new ApplicationUser
            {
                UserName = seededUserName,
                Email = "admin@seeder.com"
            };

            await userManager.CreateAsync(_seededUser, seededPassword);
            await userManager.AddClaimAsync(_seededUser, new Claim(ClaimTypes.Name, _seededUser.UserName));
            await userManager.AddClaimAsync(_seededUser, new Claim(ClaimTypes.NameIdentifier, _seededUser.Id));
            await userManager.AddClaimAsync(_seededUser, new Claim(ClaimTypes.Role, "Administrator"));

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
                    new Patient { Name = "Tutu", User = _seededUser },
                    new Patient { Name = "Fifi", User = _seededUser },
                    new Patient { Name = "Brownie", User = _seededUser },
                    new Patient { Name = "Biter", User = _seededUser },
                    new Patient { Name = "Rush", User = _seededUser },
                    new Patient { Name = "Treble", User = _seededUser },
                    new Patient { Name = "Lassie", User = _seededUser },
                    new Patient { Name = "Bolt", User = _seededUser },
                    new Patient { Name = "Brownie", User = _seededUser },
                    new Patient { Name = "Beethoven", User = _seededUser },
                    new Patient { Name = "Hooch", User = _seededUser },
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

            var generalHeathField = await fieldService.AddAsync(new MedicalField { Name = "General Health" });
            var surgeryField = await fieldService.AddAsync(new MedicalField { Name = "Surgery" });

            var vetMichael = await vetService.AddAsync(new Veterinarian { Name = "Michael Brown" });
            var vetLiza = await vetService.AddAsync(new Veterinarian { Name = "Liza Gomez" });

            await specService.AddAsync(vetMichael, generalHeathField);
            await specService.AddAsync(vetMichael, surgeryField);
            await specService.AddAsync(vetLiza, surgeryField);



        }


    }
}
