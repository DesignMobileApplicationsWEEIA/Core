using System;
using Domain.Model.Api;
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
                var searchedBuilding = _unitOfWork.Buildings.Find(building => building.Equals(place.Building));
            }
            return Result<bool>.Error();
        }
    }
}