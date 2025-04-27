using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Client.Queries
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<RO.DevTest.Domain.Entities.Client>>
    {
        private readonly IClientRepository _clientRepository;
        public GetAllClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<RO.DevTest.Domain.Entities.Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients;
        }

    }
}
