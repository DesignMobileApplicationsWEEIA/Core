using Domain.Services.Implementations;
using Domain.Services.Interfaces;
using Domain.Tests.Mocks;

namespace Domain.Tests.Services
{
    public class BuildingServiceTests
    {
        private IBuildingService _buildingService;
        private UnitOfWorkMock _unitOfWorkMock;

        public BuildingServiceTests()
        {
            _unitOfWorkMock = new UnitOfWorkMock(BuildingRepositoryMock.MockedUnitOfWork(), PlacesRepositoryMock.MockedUnitOfWork());
            _buildingService = new BuildingService(_unitOfWorkMock.IUnitOfWorkMock.Object);
        }
    }
}