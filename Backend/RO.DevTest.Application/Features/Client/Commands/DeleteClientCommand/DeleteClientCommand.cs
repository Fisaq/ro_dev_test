using MediatR;
using RO.DevTest.Application.Features.Client.Response;

namespace RO.DevTest.Application.Features.Client.Commands.DeleteClientCommand
{
    public class DeleteClientCommand : IRequest<ClientResponse>
    {
        public Guid ClientId { get; set; }
    }
}
