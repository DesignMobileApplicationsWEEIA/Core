using Core.Domain.Repositories.Interfaces;
using Moq;

namespace Domain.Tests.Mocks
{
    public class BuildingRepositoryMock : IMock<IBuildingRepository>
    {
        public static Mock<IBuildingRepository> MockedUnitOfWork() => new BuildingRepositoryMock().Get();

        public Mock<IBuildingRepository> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}