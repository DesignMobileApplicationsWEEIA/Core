using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Database.Interfaces;
using Domain.Model;
using Domain.Repositories.Abstractions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Implementations
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Building FindAllInfo(Expression<Func<Building, bool>> predicate)
        {
            return DbContext.Buildings.Include(x => x.Places).Include(x => x.Faculties).AsNoTracking().FirstOrDefault(predicate);
        }
    }
}
