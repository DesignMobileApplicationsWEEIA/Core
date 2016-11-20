using System;
using System.Globalization;
using Domain.Model;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services.Implementations
{
    public class BuildingService : IBuildingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool _shouldBeDisposed = true;

        public BuildingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            if (!_shouldBeDisposed) return;
            _shouldBeDisposed = false;
            _unitOfWork?.Dispose();
        }

        public Result<Building> SearchBuildingWithPhoneData(PhoneData phoneData)
        {
            string key = _unitOfWork.Cache.GenerateKey(nameof(BuildingService), nameof(SearchBuildingWithPhoneData),
                phoneData?.Direction.ToString("0.00", CultureInfo.InvariantCulture),
                phoneData?.PhoneLocation.Latitude.ToString("0.00", CultureInfo.InvariantCulture),
                phoneData?.PhoneLocation.Longitude.ToString("0.00", CultureInfo.InvariantCulture));
            var building = _unitOfWork.Buildings.FindAllInfo(x => phoneData.IsInVisualField(x));
            return _unitOfWork.Cache.GetOrStore(key, () => Result<Building>.Wrap(building), TimeSpan.FromDays(1));
        }
    }
}