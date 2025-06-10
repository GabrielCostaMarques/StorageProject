using StorageProject.Domain.Entities;
using StorageProject.Domain.Entity;

namespace StorageProject.Application.DTOs
{
    public class ProductDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
    }
}
