using System;
using System.Collections.Generic;
using LanguageExt;
using Core.Domain.Model;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Option<IEnumerable<TEntity>> GetBy(Func<TEntity, bool> predicate);
        Option<IEnumerable<TEntity>> GetAll();
        Option<bool> Insert(TEntity entity);
        Option<bool> Update(TEntity entity);
        Option<bool> Delete(TEntity entity);
        Option<int> SaveChanges();        
    }
}
