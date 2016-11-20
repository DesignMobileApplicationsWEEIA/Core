using Domain.Model.Api;

namespace Domain.Services.Interfaces
{
    public interface IPlaceService
    {
        Result<bool> Add(ApiPlace place, string userId);
    }
}