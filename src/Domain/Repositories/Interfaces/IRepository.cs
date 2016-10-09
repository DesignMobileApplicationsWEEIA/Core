using System;
using System.Collections.Generic;
using LanguageExt;
using Core.Domain.Model;
using System.Threading.Tasks;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetBy(Func<TEntity, bool> predicate);
        Task<List<TEntity>> GetByAsync(Func<TEntity, bool> predicate);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        bool Insert(TEntity entity);
        Task<bool> InsertAsync(TEntity entity);
        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
