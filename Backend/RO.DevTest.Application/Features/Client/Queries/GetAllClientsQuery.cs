using MediatR;

namespace RO.DevTest.Application.Features.Client.Queries
{
    public class GetAllClientsQuery : IRequest<List<RO.DevTest.Domain.Entities.Client>> { }

}
