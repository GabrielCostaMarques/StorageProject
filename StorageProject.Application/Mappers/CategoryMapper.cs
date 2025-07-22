using StorageProject.Application.DTOs.Category;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDTO(this Category category)
        {
            return new CategoryDTO
            {
                Name = category.Name
            };
        }
        public static Category ToEntity(this CategoryDTO dto)
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                Name = dto.Name
            };
        }

        public static void ToEntity(this UpdateCategoryDTO dto, Category category)
        {
            category.Id = dto.Id;
            category.Name = dto.Name;

        }
    }
}
