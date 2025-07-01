using StorageProject.Application.DTOs.Requests;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Contracts
{
    public interface IBrandService
    {

        public Task<IEnumerable<Brand>> GetAllAsync();
        public Task<Guid> GetByIdAsync(Guid id);
        public Task<Brand> CreateAsync(BrandDTO brandDTO);
        public Task<Brand> UpdateAsync(BrandDTO brandDTO);
        public void DeleteById(Guid id);

    }
}
