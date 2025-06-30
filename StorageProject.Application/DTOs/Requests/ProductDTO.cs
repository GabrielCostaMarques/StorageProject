namespace StorageProject.Application.DTOs.Requests
{
    public class ProductDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
