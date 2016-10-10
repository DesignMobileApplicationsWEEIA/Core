using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;
using Domain.Repositories.Abstractions;

namespace Core.Domain.Repositories.Implementations
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(IDbManager dbManager) : base(dbManager)
        {
        }
    }
}
