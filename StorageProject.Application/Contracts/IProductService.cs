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
        Task<ProductResponseDTO> GetByIdAsync(Guid id);
        Task<ProductResponseDTO> CreateAsync(ProductDTO productDTO);
        Task<ProductResponseDTO> UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(Guid id);
    }
}
