using MediatR;

namespace RO.DevTest.Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public IList<string>? Roles { get; set; } = new List<string>();
    }
}
