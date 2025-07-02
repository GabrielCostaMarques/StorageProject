using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.DTOs.Response;
using StorageProject.Application.ModelResult;

namespace StorageProject.Application.Contracts
{
    public interface IProductService : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        Task<Result<IEnumerable<ProductResponseDTO>>> GetAllAsync();
        Task<Result<ProductResponseDTO>> GetByIdAsync(Guid id);
        Task CreateAsync(ProductDTO productDTO);
        Task<ProductResponseDTO> UpdateAsync(ChangeProductDTO changeProductDTO);
        Task RemoveAsync(Guid id);
    }
}
