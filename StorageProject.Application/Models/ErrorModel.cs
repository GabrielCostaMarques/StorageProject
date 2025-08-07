namespace StorageProject.Application.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public string? Details{ get; set; }
        public List<ValidationError>? Errors { get; set; }

    }

    
}
