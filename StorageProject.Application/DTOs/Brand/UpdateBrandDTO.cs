namespace StorageProject.Application.DTOs.Brand
{
    public record UpdateBrandDTO : BrandDTO
    {
        public Guid Id { get; init; }
    }
}
