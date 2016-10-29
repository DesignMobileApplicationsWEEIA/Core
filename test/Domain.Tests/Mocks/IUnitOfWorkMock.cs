using Core.Domain.Repositories.Interfaces;
using Moq;

namespace Domain.Tests.Mocks
{
    public class IUnitOfWorkMock : IMock<IUnitOfWork>
    {
        public static Mock<IUnitOfWork> MockedUnitOfWork() => new IUnitOfWorkMock().Get();

        public Mock<IUnitOfWork> Get()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(work => work.Buildings);
            return mock;
        }
    }
}