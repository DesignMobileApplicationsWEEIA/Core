using System;
using System.Collections.Generic;
using Core.Domain.Model;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetBy(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        int SaveChanges();        
    }
}
