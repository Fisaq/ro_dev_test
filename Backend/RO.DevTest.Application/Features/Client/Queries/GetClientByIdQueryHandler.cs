using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Client.Queries
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, RO.DevTest.Domain.Entities.Client>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientByIdQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<RO.DevTest.Domain.Entities.Client> Handle(GetClientByIdQuery command, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(command.ClientId);
            if (client == null)
            {
                throw new BadRequestException($"Client with id {command.ClientId} not found.");
            }
            return client;
        }
    }
}
