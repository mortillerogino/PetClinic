using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        int GetCount();
    }
}
