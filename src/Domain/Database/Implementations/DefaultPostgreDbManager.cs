using Core.Domain.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Database.Implementations
{
    public class DefaultPostgreDbManager : DbContext, IDbManager
    {
        public DefaultPostgreDbManager()
        {
        }
    }
}
