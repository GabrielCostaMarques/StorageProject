using System.ComponentModel.DataAnnotations;

namespace StorageProject.Application.DTOs.Product
{
    public record CreateProductDTO
    {
        [Required(ErrorMessage = "The field {0} must be filled")]
        [Length(3, 50, ErrorMessage = "The field {0} must have between 3 to 50 caracteres")]
        public required string Name { get; init; }

        [MaxLength(250, ErrorMessage = "The field {1} must have a maximum of 250 characters")]
        public string? Description { get; init; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; init; }

        [Required(ErrorMessage = "The field {3} must be filled")]
        public Guid BrandId { get; init; }

        [Required(ErrorMessage = "The field {3} must be filled")]
        public Guid CategoryId { get; init; }
    }
}
