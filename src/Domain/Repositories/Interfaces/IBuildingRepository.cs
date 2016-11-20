using System;
using System.Linq.Expressions;
using Domain.Model;

namespace Domain.Repositories.Interfaces
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Building FindAllInfo(Expression<Func<Building, bool>> predicate);
    }
}
