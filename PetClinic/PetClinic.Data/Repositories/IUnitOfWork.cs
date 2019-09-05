using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Repositories
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientsRepository { get; }
        IVeterinarianRepository VeterinarianRepository { get; }
        IDiagnosisRepository DiagnosisRepository { get; }
        ISpecializationRepository SpecializationRepository { get; }
        IFieldRepository FieldRepository { get; }

        void Commit();

        Task<int> CommitAsync();
    }
}
