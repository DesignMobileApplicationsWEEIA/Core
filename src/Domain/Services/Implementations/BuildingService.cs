using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain.Model.Database;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Domain.Model.Api;
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
            return _unitOfWork.Cache.GetOrStore(key, () =>
            {
                return
                    Result<Building>.Wrap(_unitOfWork.Buildings.FindAllInfo(
                        x => x.Places.Any(y => Math.Abs(y.Latitude - phoneData.PhoneLocation.Latitude) < double.Epsilon && Math.Abs(y.Longitude - phoneData.PhoneLocation.Longitude) < double.Epsilon)));
            }, TimeSpan.FromDays(1));
        }

        public Result<IEnumerable<Building>> GetAll()
        {
            return Result<Building>.Wrap(_unitOfWork.Buildings.FindAll());
        }
    }
}