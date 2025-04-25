using MediatR;
using RO.DevTest.Application.Features.Product.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Product.Commands.CreatProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new RO.DevTest.Domain.Entities.Product(command.Name, command.Description ?? string.Empty, command.Price, command.Stock);

            await _productRepository.CreateAsync(product);

            return new ProductResponse(true,"Product created successfully",product.ProductId);
            
        }
    }
}
