using NerdStore.Shared.DomainObjects;
using System;

namespace NerdStore.Shared.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
