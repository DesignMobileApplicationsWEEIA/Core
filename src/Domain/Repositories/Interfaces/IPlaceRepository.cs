using System;
using System.Collections.Generic;
using Core.Domain.Model;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IPlaceRepository : IRepository<Place>
    {
        IEnumerable<Place> GetPlacesWithBuilding(Func<Place, bool> predicate);
    }
}
