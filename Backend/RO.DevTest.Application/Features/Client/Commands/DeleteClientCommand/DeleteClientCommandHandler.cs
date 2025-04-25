using MediatR;
using RO.DevTest.Application.Features.Client.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Client.Commands.DeleteClientCommand
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, ClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<ClientResponse> Handle(DeleteClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(command.ClientId);

            if (client == null)
            {
                return new ClientResponse(false, "Client not found", command.ClientId);
            }
            await _clientRepository.DeleteAsync(client);

            return new ClientResponse(true, "Client deleted successfully", command.ClientId);
        }
    }
}
