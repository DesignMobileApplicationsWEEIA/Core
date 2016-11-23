using System.Collections.Generic;
using Domain.Model.Api;
using Domain.Model.Database;

namespace Domain.Services.Interfaces
{
    public interface IBuildingService : IService
    {
        Result<Building> SearchBuildingWithPhoneData(PhoneData phoneData);
        Result<IEnumerable<Building>> GetAll();
    }
}