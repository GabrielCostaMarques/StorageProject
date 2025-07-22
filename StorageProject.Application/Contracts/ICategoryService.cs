using Ardalis.Result;
using StorageProject.Application.DTOs.Category;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Contracts
{
    public interface ICategoryService
    {

        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<CategoryDTO> GetByIdAsync(Guid id);
        public Task<Result> CreateAsync(CategoryDTO categoryDTO);
        public Task<Result> UpdateAsync(CategoryDTO categoryDTO);
        public Task<Result> RemoveAsync(Guid id);
    }
}
