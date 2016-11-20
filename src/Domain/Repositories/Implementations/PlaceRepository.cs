using System;
using System.Collections.Generic;
using Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Database.Interfaces;
using Domain.Model;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Implementations
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(IDbManager dbManager) : base(dbManager)
        {
        }

        public IEnumerable<Place> GetPlacesWithBuilding(Func<Place, bool> predicate)
        {
            return DbManager.Places.Include(x => x.Building).Where(predicate).ToList();
        }
    }
}