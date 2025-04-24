using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Interfaces.TokenService
{
    public interface ITokenService
    {
        string GetToken(User user, List<string> roles);
    }
}
