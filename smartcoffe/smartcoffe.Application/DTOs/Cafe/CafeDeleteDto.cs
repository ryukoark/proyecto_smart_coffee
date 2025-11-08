namespace smartcoffe.Application.DTOs.Cafe
{
    public class CafeDeleteDto
    {
        public int Id { get; set; }
        public string? Reason { get; set; }
        public string? DeletedBy { get; set; }
        public string? Status { get; set; } = "Inactive";
    }
}