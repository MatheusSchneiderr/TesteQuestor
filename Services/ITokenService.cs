using TesteQuestor.DTOs.Auth;

namespace TesteQuestor.Services;

public interface ITokenService
{
    LoginResponse GenerateToken(string username);
}
