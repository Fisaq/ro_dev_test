using MediatR;
using RO.DevTest.Application.Features.Product.Response;

namespace RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<ProductResponse>
    {
        public Guid ProductId { get; set; }
    }
}
