using MediatR;
using RO.DevTest.Application.Features.Product.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if (product == null)
            {
                throw new BadRequestException("Product not found");
            }

            product.Update(command.Name, command.Description ?? string.Empty, command.Price, command.Stock);
            await _productRepository.UpdateAsync(product);

            return new ProductResponse(true, "Product updated successfully", product.ProductId);
        }
    }
}
