using Core.Domain.Repositories.Interfaces;
using Moq;

namespace Domain.Tests.Mocks
{
    public class UnitOfWorkMock : IMock<IUnitOfWork>
    {
        public static Mock<IUnitOfWork> MockedUnitOfWork() => new UnitOfWorkMock().Get();

        public Mock<IUnitOfWork> Get()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(work => work.Buildings);
            return mock;
        }
    }
}