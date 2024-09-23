﻿using CineNow.Domain.Common;

namespace CineNow.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        Task<int> SaveAsync(CancellationToken cancellationToken);
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken);
        Task Rollback();
    }
}
