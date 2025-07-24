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

        public async Task<Result> CreateAsync(CreateCategoryDTO createCategoryDTO)
        {
            var entity = createCategoryDTO.ToEntity();
            if (!entity.Name.Any())
            {
                return Result.Conflict("Category name cannot be empty.");
            }
            var category = await _unitOfWork.CategoryRepository.Create(entity);

            await _unitOfWork.CommitAsync();
            return Result.SuccessWithMessage("Category created successfully.");
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
           var entity = await _unitOfWork.CategoryRepository.GetAll();

           return entity.Select(c =>c.ToDTO());
        }

        public async Task<Result<CategoryDTO>> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.CategoryRepository.GetById(id);
            if (entity == null)
            {
                return Result.NotFound("Category not found");
            }

            return entity.ToDTO();
        }

        public async Task<Result> RemoveAsync(Guid id)
        {
            var entity = await _unitOfWork.CategoryRepository.GetById(id);
            if (entity == null)
            {
                return Result.NotFound("Category not found");

            }

            _unitOfWork.CategoryRepository.Delete(entity);
            await _unitOfWork.CommitAsync();
            return Result.SuccessWithMessage("Category removed successfully.");
        }

        public async Task<Result> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var entity = await _unitOfWork.CategoryRepository.GetById(updateCategoryDTO.Id);

            if (entity == null)
            {
                return Result.NotFound("Category not found");
            }
            updateCategoryDTO.ToEntity(entity);
            await _unitOfWork.CommitAsync();
            return Result.SuccessWithMessage("Category updated successfully.");

        }
    }
}
