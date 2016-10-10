using System;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IPlaceRepository PlaceRepository { get; }
        int Complete();
    }
}