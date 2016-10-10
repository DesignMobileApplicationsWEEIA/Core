using System;
using Core.Domain.Model;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        TEntity GetById()
    }
}
