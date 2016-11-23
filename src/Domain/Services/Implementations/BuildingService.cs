using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain.Model.Database;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Domain.Model.Api;
using System.Linq;

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
            var place =
                _unitOfWork.Places.FindAll()?.FirstOrDefault(place1 =>
                        Math.Abs(place1.Latitude - phoneData.PhoneLocation.Latitude) < double.Epsilon &&
                        Math.Abs(place1.Longitude - phoneData.PhoneLocation.Longitude) < double.Epsilon);
            long buildingId = place?.BuildingId ?? -1L;
            var building = _unitOfWork.Buildings.FindAll()?.FirstOrDefault(x => x.Id == buildingId);

            if (building != null)
            {
                var faculties = _unitOfWork.Faculties.FindAll().Where(x => x.BuildingId == buildingId)?.ToList();
                if (faculties?.Any() ?? false)
                {
                    faculties.ForEach(x =>
                    {
                        var logo = _unitOfWork.Logos.FindAll().FirstOrDefault(l => l.FacultyId == x.Id);
                        x.Logo = logo;
                    });
                    building.Faculties = faculties?.ToList();
                }
                return Result<Building>.Wrap(building);
            }
            return Result<Building>.Error();             
        }

        public Result<IEnumerable<Building>> GetAll()
        {
            return Result<Building>.Wrap(_unitOfWork.Buildings.FindAll());
        }
    }
}