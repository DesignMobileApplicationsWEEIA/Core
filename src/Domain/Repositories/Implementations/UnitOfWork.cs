using Core.Domain.Database.Interfaces;
using Core.Domain.Repositories.Interfaces;

namespace Domain.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbManager _dbManager;

        public UnitOfWork(IDbManager dbManager)
        {
            _dbManager = dbManager;
            PlaceRepository = new PlaceRepository(_dbManager);
        }

        public IPlaceRepository PlaceRepository { get; }
        public int Complete()
        {
            return _dbManager.SaveChanges();
        }
    }
}