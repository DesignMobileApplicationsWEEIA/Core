using Domain.Repositories.Interfaces;
using Moq;

namespace Domain.Tests.Mocks
{
    public class PlacesRepositoryMock : IMock<IPlaceRepository>
    {
        public static Mock<IPlaceRepository> MockedUnitOfWork() => new PlacesRepositoryMock().Get();

        public Mock<IPlaceRepository> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}