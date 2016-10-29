using Moq;

namespace Domain.Tests.Mocks
{
    public interface IMock<T> where T : class
    {
        Mock<T> Get();
    }
}