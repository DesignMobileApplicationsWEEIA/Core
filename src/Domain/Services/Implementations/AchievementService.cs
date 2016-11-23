using System.Collections.Generic;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services.Implementations
{
    public class AchievementService : IAchievementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool _shouldBeDisposed = true;

        public void Dispose()
        {
            if (!_shouldBeDisposed) return;
            _shouldBeDisposed = false;
            _unitOfWork?.Dispose();
        }

        public AchievementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result<IEnumerable<Achievement>> GetAll()
        {
            return Result<IEnumerable<Achievement>>.Wrap(_unitOfWork.Achievements.FindAll());
        }

    }
}
