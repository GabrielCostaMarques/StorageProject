using StorageProject.Application.DTOs;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Contracts
{
    public interface IProductService : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        Task<ICollection<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> CreateAsync(ProductDTO productDTO);
        Task<Product> UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(Guid id);
    }
}
