using EfRelationshipsAndGraphs.Core.Repositories;
using System;

namespace EfRelationshipsAndGraphs.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMoeRepository Moes { get; }
        int Complete();
    }
}