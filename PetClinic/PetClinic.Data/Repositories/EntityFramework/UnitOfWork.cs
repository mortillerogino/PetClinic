using PetClinic.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PetClinicContext _context;
        private bool _disposed = false;

        public UnitOfWork(PetClinicContext context)
        {
            _context = context;
        }

        private IPatientRepository _patientRepository;
        public IPatientRepository PatientsRepository
        {
            get
            {
                if (_patientRepository == null)
                {
                    _patientRepository = new PatientRepository(_context);
                }

                return _patientRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
