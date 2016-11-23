using Domain.Model.Api;
using Domain.Model.Database;

namespace Domain.Services.Interfaces
{
    public interface IFacultyService : IService
    {
        Result<Faculty> GetAll();
    }
}
