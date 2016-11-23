using System.Collections.Generic;
using Domain.Model.Api;
using Domain.Model.Database;

namespace Domain.Services.Interfaces
{
    public interface IPlaceService : IService
    {
        Result<bool> Add(ApiPlace place);
        Result<IEnumerable<Place>> GetAll();
    }
}