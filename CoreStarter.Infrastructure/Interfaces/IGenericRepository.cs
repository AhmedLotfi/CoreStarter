using CoreStarter.Infrastructure.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreStarter.Infrastructure.Interfaces
{
    public interface IGenericRepository<T, TEntityPK> where T : EntityUtlities.EntityPK<TEntityPK>
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
