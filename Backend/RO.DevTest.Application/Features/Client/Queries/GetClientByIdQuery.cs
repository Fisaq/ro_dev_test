using MediatR;

namespace RO.DevTest.Application.Features.Client.Queries
{
    public class GetClientByIdQuery : IRequest<RO.DevTest.Domain.Entities.Client>
    {
        public Guid ClientId { get; set; }
        public GetClientByIdQuery(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
