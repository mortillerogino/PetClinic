using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Repositories
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientsRepository { get; }

        void Commit();

        Task<int> CommitAsync();
    }
}
