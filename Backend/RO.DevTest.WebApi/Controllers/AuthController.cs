﻿using MediatR;
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
    private readonly ILogger<AuthController> _logger;

    public AuthController(IMediator mediator, ILogger<AuthController> logger)
    {
        _mediator = mediator;
        _logger = logger;
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
            _logger.LogWarning("Register command is null");

            return BadRequest("Invalid registration attempt.");
        }
        try
        {
            _logger.LogInformation("Processing register for user {Username}", command.Username);

            var response = await _mediator.Send(command);

            _logger.LogInformation("Register successful for user {Username}", command.Username);

            return Ok(response);
        }
        catch (BadRequestException req)
        {
            _logger.LogWarning("Register failed for user {Username}: {Message}", command.Username, req.Message);
            return BadRequest(req.Message);
        }
    }

}
