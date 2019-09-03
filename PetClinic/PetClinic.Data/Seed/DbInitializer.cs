using PetClinic.Core.Models;
using PetClinic.Data.Models;
using PetClinic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var patientsCount = unitOfWork.PatientsRepository.GetCountAsync();
            if (patientsCount.Result > 0)
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

                foreach (Patient p in patients)
                {
                    unitOfWork.PatientsRepository.Insert(p);

                }

                unitOfWork.Commit();
            }

        }
    }
}
