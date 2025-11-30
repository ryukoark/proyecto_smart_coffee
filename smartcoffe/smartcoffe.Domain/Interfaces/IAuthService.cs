using smartcoffe.Domain.Entities;

namespace smartcoffe.Domain.Interfaces;

public interface IAuthService
{
    string GenerateToken(User user);
}