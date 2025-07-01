using StorageProject.Application.DTOs.Requests;
using StorageProject.Application.DTOs.Response;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Mappers
{
    public class ProductMapper
    {

        public static ProductResponseDTO ToResponseDTO(Product product)
        {
            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                BrandId = product.BrandId,
                BrandName = product.Brand.Name ?? string.Empty,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name ?? string.Empty,
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
