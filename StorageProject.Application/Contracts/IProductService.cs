using Ardalis.Result;
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

        Task<Result<IEnumerable<ProductResponseDTO>>> GetAllAsync();
        Task<Result<ProductResponseDTO>> GetByIdAsync(Guid id);
        Task<Result<ProductResponseDTO>> CreateAsync(ProductDTO productDTO);
        Task<Result<ProductResponseDTO>> UpdateAsync(ChangeProductDTO changeProductDTO);
        Task<Result> RemoveAsync(Guid id);
    }
}
