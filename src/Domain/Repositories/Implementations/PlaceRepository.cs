using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;
using LanguageExt;

namespace Core.Domain.Repositories.Implementations
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly IDbManager _dbManager;

        public PlaceRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public Task<bool> DeleteAsync(Place entity)
        {
            throw new NotImplementedException();
        }

        public List<Place> GetAll()
        {
            return _dbManager.Places.ToList();
        }

        public async Task<List<Place>> GetAllAsync()
        {
            var places = _dbManager.Places.ToAsyncEnumerable();
            return await places.ToList();
        }

        public List<Place> GetBy(Func<Place, bool> predicate)
        {
            var places = _dbManager.Places.Where(predicate);
            return places.ToList();
        }

        public async Task<List<Place>> GetByAsync(Func<Place, bool> predicate)
        {
            var places = _dbManager.Places.Where(predicate).ToAsyncEnumerable();
            return await places.ToList();
        }

        public bool Insert(Place entity)
        {
            var result = _dbManager.
        }

        public Task<bool> InsertAsync(Place entity)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public bool Update(Place entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Place entity)
        {
            throw new NotImplementedException();
        }
    }
}
