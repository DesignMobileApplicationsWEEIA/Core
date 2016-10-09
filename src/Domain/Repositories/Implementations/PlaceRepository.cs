using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Core.Domain.Repositories.Implementations
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly IDbManager _dbManager;

        public PlaceRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public Task<Option<bool>> DeleteAsync(Place entity)
        {
            throw new NotImplementedException();
        }

        public Option<List<Place>> GetAll()
        {
            return Optional(_dbManager.Places.ToList());
        }

        public async Task<Option<List<Place>>> GetAllAsync()
        {
            var places = _dbManager.Places.ToAsyncEnumerable();
            return Optional(await places.ToList());
        }

        public Option<List<Place>> GetBy(Func<Place, bool> predicate)
        {
            var places = _dbManager.Places.Where(predicate);
            return Optional(places.ToList());
        }

        public async Task<Option<List<Place>>> GetByAsync(Func<Place, bool> predicate)
        {
            var places = _dbManager.Places.Where(predicate).ToAsyncEnumerable();
            return Optional(await places.ToList());
        }

        public Option<bool> Insert(Place entity)
        {
            throw new NotImplementedException();
        }

        public Task<Option<bool>> InsertAsync(Place entity)
        {
            throw new NotImplementedException();
        }

        public Option<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<Option<int>> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Option<bool> Update(Place entity)
        {
            throw new NotImplementedException();
        }

        public Task<Option<bool>> UpdateAsync(Place entity)
        {
            throw new NotImplementedException();
        }
    }
}
