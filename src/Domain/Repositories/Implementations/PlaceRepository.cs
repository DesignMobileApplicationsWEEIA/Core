using System;
using System.Collections.Generic;
using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;
using Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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