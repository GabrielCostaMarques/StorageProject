using Ardalis.Result;
using StorageProject.Application.DTOs.Requests;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Contracts
{
    public interface IBrandService
    {

        public Task<IEnumerable<Brand>> GetAllAsync();
        public Task<Brand> GetByIdAsync(Guid id);
        public Task<Result<Brand>> CreateAsync(BrandDTO brandDTO);
        public Task<Result> UpdateAsync(ChangeBrandDTO changeBrandDTO);
        public Task<Result> DeleteById(Guid id);

    }
}
