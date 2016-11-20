using System;
using System.Collections.Generic;
using Domain.Model;

namespace Domain.Repositories.Interfaces
{
    public interface IPlaceRepository : IRepository<Place>
    {
        IEnumerable<Place> GetPlacesWithBuilding(Func<Place, bool> predicate);
    }
}
