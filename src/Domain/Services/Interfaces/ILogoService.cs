﻿using Domain.Model.Api;
using Domain.Model.Database;

namespace Domain.Services.Interfaces
{
    public interface ILogoService : IService
    {
        Result<Logo> GetAll();
    }
}
