using StorageProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageProject.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product> DeleteAsync(Product product, CancellationToken cancellationToken = default);
        Task<List<Product>?> GetAllAsync(int skip = 0, int take = 40, CancellationToken cancellationToken = default);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    }
}
