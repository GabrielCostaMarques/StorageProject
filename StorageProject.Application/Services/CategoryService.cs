using Ardalis.Result;
using StorageProject.Application.Contracts;
using StorageProject.Application.DTOs.Category;
using StorageProject.Application.Mappers;
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

        public async Task<Result> CreateAsync(CategoryDTO categoryDTO)
        {
            var entity = categoryDTO.ToEntity();
            if (!entity.Name.Any())
            {
                return Result.Conflict("Category name cannot be empty.");
            }
            var category = await _unitOfWork.CategoryRepository.Create(entity);

            await _unitOfWork.CommitAsync();
            return Result.SuccessWithMessage("Category created successfully.");
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
