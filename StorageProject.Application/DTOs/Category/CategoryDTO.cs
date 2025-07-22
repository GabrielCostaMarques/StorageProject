namespace StorageProject.Application.DTOs.Category
{
    public record CategoryDTO
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}
