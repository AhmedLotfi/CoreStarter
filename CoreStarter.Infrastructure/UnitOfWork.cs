using CoreStarter.EFCore._DbContext;
using CoreStarter.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace CoreStarter.Infrastructure.Specifications
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreStarterContext _context;
        private Hashtable _repositories;

        public UnitOfWork(CoreStarterContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity, TEnityPK> Repository<TEntity, TEnityPK>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<,>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TEnityPK)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity, TEnityPK>)_repositories[type];
        }
    }
}
