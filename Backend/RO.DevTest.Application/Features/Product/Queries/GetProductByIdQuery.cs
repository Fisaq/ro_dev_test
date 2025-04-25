using MediatR;

namespace RO.DevTest.Application.Features.Product.Queries
{
    public class GetProductByIdQuery : IRequest<RO.DevTest.Domain.Entities.Product>
    {
        public Guid ProductId { get; set; }

        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
