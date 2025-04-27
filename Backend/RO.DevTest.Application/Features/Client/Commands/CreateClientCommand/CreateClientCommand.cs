using RO.DevTest.Application.Features.Client.Response;
using MediatR;

namespace RO.DevTest.Application.Features.Client.Commands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<ClientResponse>
    {
        public string ClientName { get; set; } = string.Empty;
    }
}
