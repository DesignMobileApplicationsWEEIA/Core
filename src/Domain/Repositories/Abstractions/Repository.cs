using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;

namespace Domain.Repositories.Abstractions
{
    public abstract class Repository<T>: IRepository<T> where T : BaseEntity
    {
        
    }
}