using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.DTOs.Response;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Mappers
{
    public class ProductMapper
    {

        public static ProductResponseDTO ToResponseDTO(Product product, string brandName, string categoryName)
        {
            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                BrandId = product.BrandId,
                BrandName = brandName ?? string.Empty,
                CategoryId = product.CategoryId,
                CategoryName = categoryName ?? string.Empty,
                Quantity = product.Quantity,
                Status = product.Status,
            };
        }
        public static Product ToEntity(ProductDTO dto)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Quantity = dto.Quantity,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId
            };
        }

    }
}
