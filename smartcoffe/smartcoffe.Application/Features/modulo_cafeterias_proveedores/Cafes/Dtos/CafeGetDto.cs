public class CafeGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? Company { get; set; }
    public string Status { get; set; } = null!;
}