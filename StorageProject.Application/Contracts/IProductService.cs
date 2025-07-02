using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.DTOs.Response;

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
        Task CreateAsync(ProductDTO productDTO);
        Task<ProductResponseDTO> UpdateAsync(ChangeProductDTO changeProductDTO);
        Task RemoveAsync(Guid id);
    }
}
