using StorageProject.Domain.Entities.Enums;

namespace StorageProject.Application.DTOs.Response
{
    public class ProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public ProductStatus Status { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }

}
