using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Model.Database;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll();
        Task<IEnumerable<TEntity>> FindAllAsync();
        IQueryResult<TEntity> Add(TEntity entity);
        OperationStatus AddRange(IEnumerable<TEntity> entities);
        OperationStatus Remove(TEntity entity);
        OperationStatus RemoveRange(IEnumerable<TEntity> entities);
    }
}
