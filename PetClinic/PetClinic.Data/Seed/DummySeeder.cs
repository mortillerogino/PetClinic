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
        private UserManager<ApplicationUser> _userManager;

        public DummySeeder(IServiceProvider services)
        {
            _services = services;
        }

        public async Task SeedUser()
        {
            string seededUserName = "admin";
            string seededPassword = "1234";

            _userManager = _services.GetService<UserManager<ApplicationUser>>();
            _seededUser = await _userManager.FindByNameAsync(seededUserName);

            

            if (_seededUser != null)
            {
                return;
            }

            _seededUser = new ApplicationUser
            {
                UserName = seededUserName,
                Email = "admin@seeder.com"
            };

            await _userManager.CreateAsync(_seededUser, seededPassword);
            await _userManager.AddClaimAsync(_seededUser, new Claim(ClaimTypes.Name, _seededUser.UserName));
            await _userManager.AddClaimAsync(_seededUser, new Claim(ClaimTypes.NameIdentifier, _seededUser.Id));
            await _userManager.AddClaimAsync(_seededUser, new Claim(ClaimTypes.Role, "Administrator"));

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

            await CreateVetLogin(userName: "michael", email: "michael@vets.com", password: "1234");
            await CreateVetLogin(userName: "liza", email: "liza@vets.com", password: "1234");
        }

        private async Task CreateVetLogin(string userName, string email, string password)
        {
            var newVetLogin = new ApplicationUser
            {
                UserName = userName,
                Email = email
            };

            await _userManager.CreateAsync(newVetLogin, password);
            await _userManager.AddClaimAsync(newVetLogin, new Claim(ClaimTypes.Name, newVetLogin.UserName));
            await _userManager.AddClaimAsync(newVetLogin, new Claim(ClaimTypes.NameIdentifier, newVetLogin.Id));
            await _userManager.AddClaimAsync(newVetLogin, new Claim(ClaimTypes.Role, "Veterinarian"));
        }
    }
}
