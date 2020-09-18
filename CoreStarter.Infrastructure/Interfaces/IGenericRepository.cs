using CoreStarter.Infrastructure.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreStarter.Infrastructure.Interfaces
{
    public interface IGenericRepository<T, TEntityPK> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(ISpecification<T> spec);

        Task<T> GetByIdAsync(TEntityPK entityPK);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
