using MediatR;
using RO.DevTest.Application.Features.Client.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Client.Commands.CreateClientCommand
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientResponse>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientResponse> Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            var client = new RO.DevTest.Domain.Entities.Client(command.ClientId, command.SaleId, command.ClientName, command.SaleDate, command.TotalValue);
            
            await _clientRepository.CreateAsync(client);
            
            return new ClientResponse(true, "Client created successfully", client.ClientId);
        }
        
    }
}
