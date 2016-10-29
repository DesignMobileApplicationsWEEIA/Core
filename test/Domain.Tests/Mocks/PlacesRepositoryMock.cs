using Core.Domain.Repositories.Interfaces;
using Moq;

namespace Domain.Tests.Mocks
{
    public class PlacesRepositoryMock : IMock<IPlaceRepository>
    {
        public Mock<IPlaceRepository> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}