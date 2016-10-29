using Moq;

namespace Domain.Tests.Mocks
{
    public interface IMock<T>
    {
        Mock<T> Get();
    }
}