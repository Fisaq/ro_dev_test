using MediatR;
using RO.DevTest.Application.Features.Client.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Client.Commands.UpdateClientCommand
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<ClientResponse> Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(command.ClientId);

            if (client == null)
            {
                return new ClientResponse(false, "Client not found", command.ClientId);
            }

            client.Update(command.ClientName);

            await _clientRepository.UpdateAsync(client);

            return new ClientResponse(true, "Client updated successfully", client.ClientId);
        }
    }
}
