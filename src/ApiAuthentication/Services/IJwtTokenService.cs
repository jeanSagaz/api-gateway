using ApiAuthentication.Models;

namespace ApiAuthentication.Services
{
    public interface IJwtTokenService
    {
        AuthToken? GenerateAuthToken(Login model);
    }
}
