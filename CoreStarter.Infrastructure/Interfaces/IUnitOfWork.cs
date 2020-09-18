using CoreStarter.Infrastructure.EntityUtlities;
using System;
using System.Threading.Tasks;

namespace CoreStarter.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity, TEntityPK> Repository<TEntity, TEntityPK>() where TEntity : class;

        Task<int> Complete();
    }
}