using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.Auth.Commands.LoginCommand;
using RO.DevTest.Application.Features.Auth.Commands.RegisterCommand;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.WebApi.Controllers;

[Route("api/auth")]
[OpenApiTags("Auth")]
public class AuthController: ControllerBase {

    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {

        if (command == null)
        {
            return BadRequest("Invalid login attempt.");
        }

        try
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        catch (BadRequestException req)
        {
            return BadRequest(req.Message);
        }
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid registration attempt.");
        }
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (BadRequestException req)
        {
            return BadRequest(req.Message);
        }
    }

}
