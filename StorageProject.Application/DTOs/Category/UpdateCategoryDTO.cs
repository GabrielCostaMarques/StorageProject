namespace StorageProject.Application.DTOs.Category
{
    public record UpdateCategoryDTO : CategoryDTO
    {
        public Guid Id { get; init; }
    }
}
