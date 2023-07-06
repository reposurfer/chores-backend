using chores_backend.DTOs;

namespace chores_backend.Services;

public interface IAuthManager
{
    Task<string> CreateToken();
    Task<bool> ValidateUser(LoginDTO dto);
}