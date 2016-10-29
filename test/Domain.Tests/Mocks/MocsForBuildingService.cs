using Core.Domain.Repositories.Interfaces;
using Moq;

namespace Domain.Tests.Mocks
{
    public class MocsForBuildingService : IMock<IUnitOfWork>
    {
        public Mock<IUnitOfWork> Get()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(work => work.Buildings);
            return mock;
        }
    }
}