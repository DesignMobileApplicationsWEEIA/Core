using System;
using System.Linq.Expressions;
using System.Linq;
using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;
using Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Repositories.Implementations
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(IDbManager dbManager) : base(dbManager)
        {
        }

        public Building FindAllInfo(Expression<Func<Building, bool>> predicate)
        {
            return DbManager.Buildings.Include(x => x.Places).Include(x => x.Faculties).FirstOrDefault(predicate);
        }
    }
}
