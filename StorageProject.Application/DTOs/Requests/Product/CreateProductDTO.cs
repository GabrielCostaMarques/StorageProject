using System.ComponentModel.DataAnnotations;

namespace StorageProject.Application.DTOs.Requests.Product
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage ="The field {0} must be filled")]
        [Length(3,50,ErrorMessage ="The field {0} must have between 3 to 50 caracteres")]
        public required string Name { get; set; }

        [MaxLength(250, ErrorMessage = "The field {1} must have a maximum of 250 characters")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The field {3} must be filled")]
        public Guid BrandId { get; set; }
        
        [Required(ErrorMessage = "The field {3} must be filled")]
        public Guid CategoryId { get; set; }
    }
}
