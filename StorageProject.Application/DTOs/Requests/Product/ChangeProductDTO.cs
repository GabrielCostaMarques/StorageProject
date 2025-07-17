using System.ComponentModel.DataAnnotations;

namespace StorageProject.Application.DTOs.Requests.Product
{
    public class ChangeProductDTO : CreateProductDTO
    {
        [Required(ErrorMessage = "The field {0} must be filled")]
        public Guid Id { get; set; }
    }
}
