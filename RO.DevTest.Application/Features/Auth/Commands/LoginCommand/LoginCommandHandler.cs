using MediatR;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        ///[TODO] - CREATE LOGIN HANDLER HERE  
        ///


        throw new NotImplementedException();
    }
}
