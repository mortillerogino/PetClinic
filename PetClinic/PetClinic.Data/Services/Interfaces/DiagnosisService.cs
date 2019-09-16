using PetClinic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Services.Interfaces
{
    public class DiagnosisService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosisService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
