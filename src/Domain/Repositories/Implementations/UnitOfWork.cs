using Core.Domain.Database.Interfaces;
using Core.Domain.Repositories.Implementations;
using Core.Domain.Repositories.Interfaces;
using Domain.Cache.Implementations;
using Domain.Cache.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbManager _dbManager;

        public UnitOfWork(IDbManager dbManager, IMemoryCache memoryCache)
        {
            _dbManager = dbManager;
            Places = new PlaceRepository(_dbManager);
            Buildings = new BuildingRepository(_dbManager);
            Cache = new InMemoryCacheService(memoryCache);
        }

        public IPlaceRepository Places { get; }

        public IBuildingRepository Buildings { get; }

        public ICacheService Cache { get; }

        public int Complete()
        {
            return _dbManager.SaveChanges();
        }

        public void Dispose()
        {
            _dbManager?.Dispose();
        }
    }
}