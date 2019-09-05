using Microsoft.Extensions.DependencyInjection;
using PetClinic.Core.Models;
using PetClinic.Data.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

            var patientsCount = await patientService.GetCountAsync();
            if (patientsCount > 0)
            {
                return;
            }
            else
            {
                var patients = new Patient[]
                {
                    new Patient { Id = Guid.NewGuid(), Name = "Tutu", DateAdded = DateTime.Parse("2019-09-01") },
                    new Patient { Id = Guid.NewGuid(), Name = "Fifi", DateAdded = DateTime.Parse("2019-08-31") },
                    new Patient { Id = Guid.NewGuid(), Name = "Brownie", DateAdded = DateTime.Parse("2019-08-30") },
                };

                await patientService.AddMultipleAsync(patients);

            }

        }


    }
}
