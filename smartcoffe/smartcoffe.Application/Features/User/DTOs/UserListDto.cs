namespace smartcoffe.Application.Features.User.DTOs;

public class UserListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Rrole { get; set; } = null!;
    public bool Status { get; set; }
}