using MediatR;
using RO.DevTest.Application.Features.Product.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);

            if(product == null)
            {
                throw new BadRequestException("Product not found");
            }

            await _productRepository.DeleteAsync(product);

            return new ProductResponse(true, "Product deleted successfully", product.ProductId);
        }
    }
}
