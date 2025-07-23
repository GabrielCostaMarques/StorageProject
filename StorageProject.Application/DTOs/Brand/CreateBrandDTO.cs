using System.ComponentModel.DataAnnotations;

namespace StorageProject.Application.DTOs.Brand
{
    public record CreateBrandDTO
    {
        [Required(ErrorMessage ="The Field {0} must be filled")]
        public string Name { get; set; }
    }
}
