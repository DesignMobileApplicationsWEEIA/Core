using System;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services.Implementations
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool _shouldBeDisposed = true;

        public PlaceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            if (!_shouldBeDisposed) return;
            _shouldBeDisposed = false;
            _unitOfWork?.Dispose();
        }

        public Result<bool> Add(ApiPlace place, string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var res = _unitOfWork.Buildings.Add(ApiBuilding.ToBuilding(place.Building));
                if (res.HasValue)
                {
                    var newPlace = ApiPlace.ToPlace(place);
                    newPlace.UserId = userId;
                    newPlace.BuildingId = res.Value.Id;
                    _unitOfWork.Places.Add(ApiPlace.ToPlace(place));
                    return Result<bool>.WrapValue(_unitOfWork.Complete() == 1);
                }
            }
            return Result<bool>.Error();
        }
    }
}