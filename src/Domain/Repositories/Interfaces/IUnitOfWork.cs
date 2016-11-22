﻿using System;
using Domain.Cache.Interfaces;

namespace Domain.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlaceRepository Places { get; }
        IBuildingRepository Buildings { get; }
        IAchievementRepository Achievements { get; }
        ICacheService Cache { get; }
        int Complete();
    }
}