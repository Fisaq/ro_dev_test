using MediatR;
using RO.DevTest.Application.Features.Product.Response;

namespace RO.DevTest.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string ?Description { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }
}
