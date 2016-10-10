using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Abstractions
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IDbManager DbManager;

        protected Repository(IDbManager dbManager)
        {
            DbManager = dbManager;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbManager.Set<TEntity>().Where(predicate).AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbManager.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return DbManager.Set<TEntity>().AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await DbManager.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public OperationStatus Add(TEntity entity)
        {
            var result = DbManager.Set<TEntity>().Add(entity);
            return result.IsKeySet ? OperationStatus.Succeed : OperationStatus.Error;
        }

        public OperationStatus AddRange(IEnumerable<TEntity> entities)
        {
            DbManager.Set<TEntity>().AddRange(entities);
            return OperationStatus.Succeed;
        }

        public OperationStatus Remove(TEntity entity)
        {
            var result = DbManager.Set<TEntity>().Remove(entity);
            return result.IsKeySet ? OperationStatus.Succeed : OperationStatus.Error;
        }

        public OperationStatus RemoveRange(IEnumerable<TEntity> entities)
        {
            DbManager.Set<TEntity>().RemoveRange(entities);
            return  OperationStatus.Succeed;
        }

        public abstract void Dispose();
    }
}