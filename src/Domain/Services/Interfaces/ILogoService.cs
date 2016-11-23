using Domain.Model.Api;
using Domain.Model.Database;

namespace Domain.Services.Interfaces
{
    public interface ILogoService
    {
        Result<Logo> GetByBuildingId(long id);
    }
}
