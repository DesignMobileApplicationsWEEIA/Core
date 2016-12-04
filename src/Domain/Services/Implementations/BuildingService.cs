using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain.Model.Database;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Domain.Model.Api;
using System.Linq;
using Domain.Model.Math;
using Math = Domain.Utils.Math;

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
            var userPoint = new Point(phoneData.PhoneLocation.Latitude, phoneData.PhoneLocation.Longitude);
            var place =
                _unitOfWork.Places.FindAll()?.FirstOrDefault(place1 =>
                {
                    var tmp = new Point(place1.Latitude, place1.Longitude);
                    return (tmp == userPoint) || Math.IsInPointOfView(userPoint, tmp, phoneData.Direction);
                });
            long buildingId = place?.BuildingId ?? -1L;
            var building = _unitOfWork.Buildings.FindAll()?.FirstOrDefault(x => x.Id == buildingId);

            if (building != null)
            {
                building.Places = new List<Place>() { place };
                var faculties = _unitOfWork.Faculties.FindAll()?.Where(x => x.BuildingId == buildingId).ToList();
                if (faculties?.Any() ?? false)
                {
                    faculties.ForEach(x =>
                    {
                        var logo = _unitOfWork.Logos.FindAll().FirstOrDefault(l => l.Id == x.LogoId);
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