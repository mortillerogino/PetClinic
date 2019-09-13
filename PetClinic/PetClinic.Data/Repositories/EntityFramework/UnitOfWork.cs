using PetClinic.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Repositories.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetClinicContext _context;
        private bool _disposed = false;

        public UnitOfWork(PetClinicContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
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

        private IVeterinarianRepository _veterinarianRepository;
        public IVeterinarianRepository VeterinarianRepository
        {
            get
            {
                if (_veterinarianRepository == null)
                {
                    _veterinarianRepository = new VeterinarianRepository(_context);
                }

                return _veterinarianRepository;
            }
        }

        private IDiagnosisRepository _diagnosisRepository;
        public IDiagnosisRepository DiagnosisRepository
        {
            get
            {
                if (_diagnosisRepository ==  null)
                {
                    _diagnosisRepository = new DiagnosisRepository(_context);
                }

                return _diagnosisRepository;
            }
        }

        private ISpecializationRepository _specializationRepository;
        public ISpecializationRepository SpecializationRepository
        {
            get
            {
                if (_specializationRepository == null)
                {
                    _specializationRepository = new SpecializationRepository(_context);
                }

                return _specializationRepository;
            }
        }

        private IFieldRepository _fieldRepository;
        public IFieldRepository FieldRepository
        {
            get
            {
                if (_fieldRepository == null)
                {
                    _fieldRepository = new FieldRepository(_context);
                }

                return _fieldRepository;
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }
        }

        private IUserClaimRepository _userClaimRepository;
        public IUserClaimRepository UserClaimRepository
        {
            get
            {
                if (_userClaimRepository == null)
                {
                    _userClaimRepository = new UserClaimRepository(_context);
                }

                return _userClaimRepository;
            }
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
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
