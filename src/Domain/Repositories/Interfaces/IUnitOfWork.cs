using System;

namespace Core.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IPlaceRepository Places { get; }
        int Complete();
    }
}