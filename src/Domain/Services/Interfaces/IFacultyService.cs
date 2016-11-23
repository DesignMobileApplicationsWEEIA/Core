using System.Collections.Generic;
using Domain.Model.Api;
using Domain.Model.Database;

namespace Domain.Services.Interfaces
{
    public interface IFacultyService : IService
    {
        Result<IEnumerable<Faculty>> GetAll();
    }
}
