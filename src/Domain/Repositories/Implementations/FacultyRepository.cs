using Domain.Database.Interfaces;
using Domain.Model.Database;
using Domain.Repositories.Abstractions;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Implementations
{
    public class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}