using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Product.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, RO.DevTest.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RO.DevTest.Domain.Entities.Product> Handle(GetProductByIdQuery command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);

            if (product == null)
            {
                throw new BadRequestException($"Product with id {command.ProductId} not found.");
            }

            return product;
        }
    }
}
