using System;
using System.Collections.Generic;
using PetClinic.Core.Models;

namespace PetClinic.Data.Services
{
    public interface IPatientService
    {
        void Add();
        IEnumerable<Patient> Get();
        Patient GetById(Guid id);
    }
}