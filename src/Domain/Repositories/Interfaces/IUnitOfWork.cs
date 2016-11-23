using System;

namespace Domain.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlaceRepository Places { get; }
        IBuildingRepository Buildings { get; }
        IAchievementRepository Achievements { get; }
        IFacultyRepository Faculties { get; }
        ILogoRepository Logos { get; }
        int Complete();
    }
}