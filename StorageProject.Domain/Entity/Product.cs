using StorageProject.Domain.Abstractions;
using StorageProject.Domain.Entities;
using StorageProject.Domain.Entities.Enums;

namespace StorageProject.Domain.Entity
{
    public class Product : EntityBase
    {
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ProductStatus Status { get; set; }

        public Product() { }

        public Product(Guid id, string name, string? description, Brand brand, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Brand = brand;
            Category = category;
        }

        public Product(Guid id, string name, Brand brand, Category category)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Category = category;
        }

        public ProductStatus UpdateStatus()
        {
            if (Quantity == 0 || Quantity == null) return ProductStatus.Unavailable;
            else if (Quantity >= 5) return ProductStatus.LowStock;
            else return ProductStatus.Available;
        }
    }
}
