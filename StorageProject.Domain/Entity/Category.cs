using StorageProject.Domain.Abstractions;

namespace StorageProject.Domain.Entity
{
    public class Category : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; }

        public Category() { }

        public Category(Guid id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
