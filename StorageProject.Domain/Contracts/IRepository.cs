using StorageProject.Domain.Abstractions;

namespace StorageProject.Domain.Contracts
{
    public interface IRepository<T> where T : EntityBase
    {
        public Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
        public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        public Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
        public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<ICollection<T>?> GetAllAsync(int skip = 0, int take = 40, CancellationToken cancellationToken = default);
    }
}
