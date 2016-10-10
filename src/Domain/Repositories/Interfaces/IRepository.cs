using System;
using System.Collections.Generic;
using LanguageExt;
using Core.Domain.Model;
using System.Threading.Tasks;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        List<TEntity> Find(Func<TEntity, bool> predicate);
        Task<List<TEntity>> FindAsync(Func<TEntity, bool> predicate);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        bool Insert(TEntity entity);
        bool InsertMany(TEntity entity);
        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        bool Delete(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
