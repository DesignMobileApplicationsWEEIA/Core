using System;
using System.Linq.Expressions;
using Core.Domain.Model;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Building FindAllInfo(Expression<Func<Building, bool>> predicate);
    }
}
