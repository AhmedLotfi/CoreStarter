using CoreStarter.EFCore._DbContext;
using CoreStarter.Infrastructure.EntityUtlities;
using CoreStarter.Infrastructure.Interfaces;
using CoreStarter.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreStarter.Infrastructure
{
    public class GenericRepository<T, TEntityPK> : IGenericRepository<T, TEntityPK> where T : EntityPK<TEntityPK>
    {
        private readonly CoreStarterContext _context;

        public GenericRepository(CoreStarterContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetAll(ISpecification<T> spec)
        {
            return ApplySpecification(spec);
        }

        public async Task<T> GetByIdAsync(TEntityPK entityPK)
        {
            return await _context.Set<T>().FindAsync(entityPK);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T, TEntityPK>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
