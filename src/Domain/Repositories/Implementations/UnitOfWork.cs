using Domain.Cache.Implementations;
using Domain.Cache.Interfaces;
using Domain.Database.Interfaces;
using Domain.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Repositories.Implementations
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDbManager _dbManager;
        private bool _shouldBeDisposed = true;

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
            if (_shouldBeDisposed)
            {
                _shouldBeDisposed = false;
                _dbManager?.Dispose();
                Cache?.Dispose();
            }
        }
    }
}