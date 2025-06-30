using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Requests;
using StorageProject.Domain.Contracts;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Category> CreateAsync(CategoryDTO categoryDTO)
        {
            var entity = new Category()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
            };

            await _unitOfWork.CategoryRepository.Create(entity);
            await _unitOfWork.CommitAsync();

            return entity;

        }

        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllWithIncludesAsync();
        }

        public Task<Guid> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateAsync(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
