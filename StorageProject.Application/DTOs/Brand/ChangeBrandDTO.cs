namespace StorageProject.Application.DTOs.Brand
{
    public record ChangeBrandDTO : BrandDTO
    {
        public Guid Id { get; init; }
    }
}
