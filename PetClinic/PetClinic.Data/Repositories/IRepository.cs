using PetClinic.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<PaginatedList<TEntity>> GetPaginatedList(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        int pageIndex = 1, 
        int pageSize = 10,
        params Expression<Func<TEntity, object>>[] includes);

        List<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> Query(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetById(object id);

        TEntity GetFirstOrDefault(
        Expression<Func<TEntity, bool>> filter = null,
        params Expression<Func<TEntity, object>>[] includes);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(object id);

        int GetCount();
    }
}
