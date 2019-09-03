using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByName(string name);
        TEntity GetById(int id);
        TEntity Update(TEntity updatedEntity);
        TEntity Add(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
