using StorageProject.Domain.Abstractions;
using StorageProject.Domain.Entity;

namespace StorageProject.Domain.Entities
{
    public class Brand : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; }

        public Brand() { }

        public Brand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
