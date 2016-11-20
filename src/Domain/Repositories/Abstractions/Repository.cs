using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Database.Interfaces;
using Domain.Model;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Abstractions
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IDbContext DbContext;

        protected Repository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return DbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await DbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public OperationStatus Add(TEntity entity)
        {
            var result = DbContext.Set<TEntity>().Add(entity);
            return result.IsKeySet ? OperationStatus.Succeed : OperationStatus.Error;
        }

        public OperationStatus AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            return OperationStatus.Succeed;
        }

        public OperationStatus Remove(TEntity entity)
        {
            var result = DbContext.Set<TEntity>().Remove(entity);
            return result.IsKeySet ? OperationStatus.Succeed : OperationStatus.Error;
        }

        public OperationStatus RemoveRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
            return  OperationStatus.Succeed;
        }
    }
}