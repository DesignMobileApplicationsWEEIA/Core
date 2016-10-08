using System;

namespace Core.Domain.Database.Interfaces
{
    public interface IDbManager : IDisposable
    {
        int SaveChanges();
    }
}
