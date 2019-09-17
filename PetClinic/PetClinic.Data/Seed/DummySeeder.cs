using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        private ApplicationUser _seededUser;
        private UserManager<ApplicationUser> _userManager;

        public DummySeeder(IServiceProvider services)
        {
            _services = services;
            _logger = _services.GetRequiredService<ILogger<DummySeeder>>();
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
            _logger.LogInformation($"User type Administrator Seeded in database at {DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}");
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
                    new Patient { Name = "Tutu", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Fifi", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Brownie", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Biter", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Rush", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Treble", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Lassie", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Bolt", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Brownie", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Beethoven", ApplicationUserID = _seededUser.Id },
                    new Patient { Name = "Hooch", ApplicationUserID = _seededUser.Id },
                };

                await patientService.AddMultipleAsync(patients);
                _logger.LogInformation($"Patients Seeded in database at {DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}");
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

            await specService.AddAsync(vetMichael.Id, generalHeathField.Id);
            await specService.AddAsync(vetMichael.Id, surgeryField.Id);
            await specService.AddAsync(vetLiza.Id, surgeryField.Id);

            _logger.LogInformation($"Veterinarians Seeded in database at {DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}");

            await CreateVetLogin(userName: "michael", email: "michael@vets.com", password: "1234", vetMichael);
            await CreateVetLogin(userName: "liza", email: "liza@vets.com", password: "1234", vetLiza);

            _logger.LogInformation($"User type Veterinarians Seeded in database at {DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}");
        }

        private async Task CreateVetLogin(string userName, string email, string password, Veterinarian veterinarian)
        {
            var newVetLogin = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                Veterinarian = veterinarian
            };

            await _userManager.CreateAsync(newVetLogin, password);
            await _userManager.AddClaimAsync(newVetLogin, new Claim(ClaimTypes.Name, newVetLogin.UserName));
            await _userManager.AddClaimAsync(newVetLogin, new Claim(ClaimTypes.NameIdentifier, newVetLogin.Id));
            await _userManager.AddClaimAsync(newVetLogin, new Claim(ClaimTypes.Role, "Veterinarian"));
        }
    }
}
