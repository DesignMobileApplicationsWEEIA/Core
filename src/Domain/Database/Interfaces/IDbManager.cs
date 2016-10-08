using System;
using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Database.Interfaces
{
    public interface IDbManager : IDisposable
    {
        DbSet<Place> Places { get; set; }

        DbSet<Building> Buildings { get; set; }

        DbSet<FacultyWreaper> FacultyWreapers { get; set; }
          
        int SaveChanges();
    }
}
