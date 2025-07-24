using Ardalis.Result;
using StorageProject.Application.DTOs.Category;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Contracts
{
    public interface ICategoryService
    {

        public Task<IEnumerable<CategoryDTO>> GetAllAsync();
        public Task<Result<CategoryDTO>> GetByIdAsync(Guid id);
        public Task<Result> CreateAsync(CreateCategoryDTO createCategoryDTO);
        public Task<Result> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        public Task<Result> RemoveAsync(Guid id);
    }
}
