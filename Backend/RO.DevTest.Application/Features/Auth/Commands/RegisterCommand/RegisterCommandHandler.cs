using MediatR;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Domain.Exception;
using Microsoft.Extensions.Logging;

namespace RO.DevTest.Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly UserManager<RO.DevTest.Domain.Entities.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(UserManager<RO.DevTest.Domain.Entities.User> userManager, 
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterCommandHandler> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);

            if (existingUser is not null)
            {
                _logger.LogWarning("User with username {Username} already exists", request.Username);
                throw new BadRequestException("This username already exists");
            }

            var user = new RO.DevTest.Domain.Entities.User
            {
                UserName = request.Username,
            };

            _logger.LogInformation("Creating user with username {Username}", request.Username);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                _logger.LogError("User registration failed for username '{Username}'. Errors: {Errors}", request.Username, errors);
                throw new BadRequestException($"User registration failed: {errors}");
            }

            foreach(var role in request.Roles)
            {
                _logger.LogInformation("Assigning role {Role} to user {Username}", role, request.Username);
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    _logger.LogInformation("Creating role {Role}", role);
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(user, role);
            }

            _logger.LogInformation("User {Username} registered successfully with roles: {Roles}", request.Username, string.Join(", ", request.Roles));
            return new RegisterResponse
            {
                Roles = request.Roles
            };
        }
    }
}
