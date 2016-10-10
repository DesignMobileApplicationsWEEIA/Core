using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;
using Domain.Repositories.Abstractions;

namespace Domain.Repositories.Implementations
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(IDbManager dbManager) : base(dbManager)
        {
        }

        public override void Dispose()
        {
            DbManager?.Dispose();
        }
    }
}