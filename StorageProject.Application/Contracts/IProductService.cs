using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.DTOs.Response;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Contracts
{
    public interface IProductService : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductResponseDTO>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<ProductResponseDTO> CreateAsync(ProductDTO productDTO);
        Task<Product> UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(Guid id);
    }
}
