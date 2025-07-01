using StorageProject.Application.DTOs.Requests;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Contracts
{
    public interface ICategoryService
    {

        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Guid> GetByIdAsync(Guid id);
        public Task<Category> CreateAsync(CategoryDTO categoryDTO);
        public Task<Category> UpdateAsync(CategoryDTO categoryDTO);
        public void DeleteById(Guid id);
    }
}
