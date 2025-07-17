using StorageProject.Application.DTOs.Requests.Brand;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.Mappers
{
    public static class BrandMapper
    {

        public static BrandDTO ToDTO(this Brand brand)
        {
            return new BrandDTO
            {
                Name = brand.Name
            };
        }
        public static Brand ToEntity(this BrandDTO dto)
        {
            return new Brand
            {
                Id = Guid.NewGuid(),
                Name = dto.Name
            };
        }

        public static void ToEntity(this ChangeBrandDTO dto, Brand brand)
        {
            brand.Id = dto.Id;
            brand.Name = dto.Name;

        }


    }
}
