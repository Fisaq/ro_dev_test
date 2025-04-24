using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.Auth.Commands.LoginCommand;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.WebApi.Controllers;

[Route("api/auth")]
[OpenApiTags("Auth")]
public class AuthController(IMediator mediator) : Controller {
    private readonly IMediator _mediator = mediator;

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

}
