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

        public Option<IEnumerable<Place>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Option<IEnumerable<Place>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Option<IEnumerable<Place>> GetBy(Func<Place, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Option<IEnumerable<Place>>> GetByAsync(Func<Place, bool> predicate)
        {
            throw new NotImplementedException();
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
