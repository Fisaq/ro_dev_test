using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RO.DevTest.Application.Interfaces.TokenService;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<RO.DevTest.Domain.Entities.User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(
        UserManager<RO.DevTest.Domain.Entities.User> userManager,
        ITokenService tokenService,
        ILogger<LoginCommandHandler> logger)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _logger = logger;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Username);

        //1 - Find user with the username
        if (user == null)
        {
            _logger.LogWarning("User with username {Username} not found", request.Username);
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        //2 - Check if the password is correct
        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if(!isPasswordValid)
        {
            _logger.LogWarning("Invalid password for user {Username}", request.Username);
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        //3 - Obtain the roles of the user
        var roles = await _userManager.GetRolesAsync(user);

        //4 - Generate the token
        var token = _tokenService.GetToken(user, roles.ToList());

        //5 - Return the token
        var response = new LoginResponse
        {
            AccessToken = token,
            IssuedAt=DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddHours(1),
            Roles = roles.ToList()
        };

        return response;
    }
}
