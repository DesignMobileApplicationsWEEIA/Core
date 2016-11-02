using System;
using Core.Domain.Model;
using Core.Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Domain.Utils;

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
            string key =
                $"{nameof(BuildingService)}-{nameof(SearchBuildingWithPhoneData)}-{phoneData?.Direction}-{phoneData?.PhoneLocation.Latitude}-{phoneData?.PhoneLocation.Longitude}";
            var building = _unitOfWork.Buildings.Find(x => phoneData.IsInVisualField(x));
            return _unitOfWork.Cache.GetOrStore(key, () => Result<Building>.Wrap(new Building()), TimeSpan.FromDays(1));
        }
    }
}