using System;
using Domain.Cache.Interfaces;

namespace Domain.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlaceRepository Places { get; }
        IBuildingRepository Buildings { get; }
        ICacheService Cache { get; }
        int Complete();
    }
}