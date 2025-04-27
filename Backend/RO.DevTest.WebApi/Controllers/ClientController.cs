using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.Client.Commands.CreateClientCommand;
using RO.DevTest.Application.Features.Client.Commands.UpdateClientCommand;
using RO.DevTest.Application.Features.Client.Commands.DeleteClientCommand;
using RO.DevTest.Application.Features.Client.Queries;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/clients")]
    [OpenApiTags("Clients")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IMediator mediator, ILogger<ClientController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand command)
        {

            if (command == null)
            {
                _logger.LogError("CreateClient- The command receive is null.");
                throw new BadRequestException("Client cannot be null");
            }

            try
            {
                _logger.LogInformation($"CreateClient: {command.ClientName}");

                var result = await _mediator.Send(command);

                if (result != null)
                {
                    _logger.LogInformation("CreateClient - Client created with success.");
                    return Ok(result);
                }

                return StatusCode(500, "Error during create client.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById([FromBody] UpdateClientCommand command, Guid id)
        {
            if (id != command.ClientId)
            {
                throw new BadRequestException("Client ID not found");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromBody] DeleteClientCommand command, Guid id)
        {
            if (id != command.ClientId)
            {
                throw new BadRequestException("Client ID not Found");
            }
            var result = await _mediator.Send(new DeleteClientCommand { ClientId = id });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetClientByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllClientsQuery());
            return Ok(result);
        }
    }
}
