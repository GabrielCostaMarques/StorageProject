using Ardalis.Result;
using StorageProject.Application.DTOs.Brand;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Contracts
{
    public interface IBrandService
    {

        public Task<IEnumerable<BrandDTO>> GetAllAsync();
        public Task<Result<BrandDTO>> GetByIdAsync(Guid id);
        public Task<Result<BrandDTO>> CreateAsync(BrandDTO brandDTO);
        public Task<Result> UpdateAsync(UpdateBrandDTO changeBrandDTO);
        public Task<Result> RemoveAsync(Guid id);

    }
}
