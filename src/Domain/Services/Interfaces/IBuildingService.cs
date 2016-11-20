using Domain.Model;

namespace Domain.Services.Interfaces
{
    public interface IBuildingService : IService
    {
        Result<Building> SearchBuildingWithPhoneData(PhoneData phoneData);
    }
}