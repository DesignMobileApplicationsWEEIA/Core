using Domain.ApiModel;
using Domain.Model;

namespace Domain.Services.Interfaces
{
    public interface IPlaceService
    {
        Result<bool> Add(ApiPlace place, string userId);
    }
}