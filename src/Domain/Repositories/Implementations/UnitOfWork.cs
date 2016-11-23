using Domain.Cache.Interfaces;
using Domain.Database.Interfaces;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Implementations
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private bool _shouldBeDisposed = true;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
            Places = new PlaceRepository(_dbContext);
            Buildings = new BuildingRepository(_dbContext);
            Achievements = new AchievementRepository(_dbContext);
            Faculties = new FacultyRepository(_dbContext);
        }

        public IPlaceRepository Places { get; }

        public IBuildingRepository Buildings { get; }

        public IAchievementRepository Achievements { get; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_shouldBeDisposed)
            {
                _shouldBeDisposed = false;
                _dbContext?.Dispose();
            }
        }

        public IFacultyRepository Faculties { get; }
    }
}