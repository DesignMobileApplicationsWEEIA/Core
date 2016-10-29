using Core.Domain.Repositories.Interfaces;
using Moq;

namespace Domain.Tests.Mocks
{
    public class UnitOfWorkMock : IMock<IUnitOfWork>
    {
        public UnitOfWorkMock(Mock<IBuildingRepository> buildingRepositoryMock, Mock<IPlaceRepository> placeRepostoryMock)
        {
            BuildingRepositoryMock = buildingRepositoryMock;
            PlaceRepostoryMock = placeRepostoryMock;
        }

        private Mock<IUnitOfWork> _mock;

        public Mock<IBuildingRepository> BuildingRepositoryMock { get; }

        public Mock<IPlaceRepository> PlaceRepostoryMock { get; }

        public Mock<IUnitOfWork> IUnitOfWorkMock => _mock ?? (_mock = Get());

        public Mock<IUnitOfWork> Get()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(work => work.Buildings).Returns(BuildingRepositoryMock.Object);
            mock.Setup(work => work.Places).Returns(PlaceRepostoryMock.Object);
            mock.Setup(work => work.Complete()).Returns(1);
            return mock;
        }
    }
}