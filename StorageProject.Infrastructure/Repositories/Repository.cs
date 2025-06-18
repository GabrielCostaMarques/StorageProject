using Microsoft.EntityFrameworkCore;
using StorageProject.Domain.Abstractions;
using StorageProject.Domain.Contracts;
using StorageProject.Infrasctructure.Data;

namespace StorageProject.Infrastructure.Repositories
{
    public abstract class Repository<T>(AppDbContext context) : IRepository<T> where T : EntityBase
    {

        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<T> Delete(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);

            return entity;
        }

        public async Task<ICollection<T>?> GetAll(int skip = 0, int take = 40, CancellationToken cancellationToken = default)
        => await _dbSet
                 .AsNoTracking()
                 .Skip(skip)
                 .Take(take)
                 .ToListAsync(cancellationToken);

        public async Task<T?> GetById(Guid id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync(id, cancellationToken);


        public async Task<T> Update(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
