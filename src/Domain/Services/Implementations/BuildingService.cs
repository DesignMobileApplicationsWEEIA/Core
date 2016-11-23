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

        public void Dispose()
        {
            if (!_shouldBeDisposed) return;
            _shouldBeDisposed = false;
            _unitOfWork?.Dispose();
        }

        public BuildingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public Result<Building> SearchBuildingWithPhoneData(PhoneData phoneData)
        {
            return
                Result<Building>.Wrap(_unitOfWork.Buildings.FindAllInfo(
                    x => x.Places.Any(y => Math.Abs(y.Latitude - phoneData.PhoneLocation.Latitude) < double.Epsilon && Math.Abs(y.Longitude - phoneData.PhoneLocation.Longitude) < double.Epsilon)));
        }

        public Result<IEnumerable<Building>> GetAll()
        {
            return Result<Building>.Wrap(_unitOfWork.Buildings.FindAll());
        }
    }
}