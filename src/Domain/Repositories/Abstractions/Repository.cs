using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;

namespace Domain.Repositories.Abstractions
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : BaseEntity
    {
        
    }
}