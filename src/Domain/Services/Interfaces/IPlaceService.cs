using System.Collections.Generic;
using Domain.Model.Api;
using Domain.Model.Database;

namespace Domain.Services.Interfaces
{
    public interface IPlaceService
    {
        Result<bool> Add(ApiPlace place, string userId);
        Result<IEnumerable<Place>> GetAll(ApiPlace place, string userId);
    }
}