using System;
using System.Collections.Generic;
using LanguageExt;
using Core.Domain.Model;
using System.Threading.Tasks;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Option<List<TEntity>> GetBy(Func<TEntity, bool> predicate);
        Task<Option<List<TEntity>>> GetByAsync(Func<TEntity, bool> predicate);
        Option<List<TEntity>> GetAll();
        Task<Option<List<TEntity>>> GetAllAsync();
        Option<bool> Insert(TEntity entity);
        Task<Option<bool>> InsertAsync(TEntity entity);
        Option<bool> Update(TEntity entity);
        Task<Option<bool>> UpdateAsync(TEntity entity);
        Task<Option<bool>> DeleteAsync(TEntity entity);
        Option<int> SaveChanges();
        Task<Option<int>> SaveChangesAsync();
    }
}
