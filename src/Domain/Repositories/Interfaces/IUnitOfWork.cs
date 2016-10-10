namespace Core.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IPlaceRepository PlaceRepository { get; }
        int Complete();
    }
}