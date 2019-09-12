using PetClinic.Core.Models;
using PetClinic.Data.Repositories;
using PetClinic.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Services
{
    public class FieldService : IFieldService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FieldService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Field> AddAsync(Field field)
        {
            field.Id = Guid.NewGuid();

            await _unitOfWork.FieldRepository.InsertAsync(field);
            await _unitOfWork.CommitAsync();

            return field;
        }
    }
}
