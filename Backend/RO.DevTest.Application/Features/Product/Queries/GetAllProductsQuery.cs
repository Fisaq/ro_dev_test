using MediatR;

namespace RO.DevTest.Application.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<List<RO.DevTest.Domain.Entities.Product>> { }
}
