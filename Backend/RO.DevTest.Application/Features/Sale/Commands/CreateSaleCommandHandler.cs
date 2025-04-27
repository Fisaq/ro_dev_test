using MediatR;
using RO.DevTest.Application.Features.Sale.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Sale.Commands
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, SaleResponse>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IProductRepository _productRepository;

        public CreateSaleCommandHandler(ISaleRepository saleRepository, ISaleItemRepository saleItemRepository, IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _saleItemRepository = saleItemRepository;
            _productRepository = productRepository;
        }

        public async Task<SaleResponse> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            //Create the instaance of the sale
            var sale = new RO.DevTest.Domain.Entities.Sale(command.ClientId)
            {
                SaleDate = command.Date
            };

            // Add sale items to the sale
            foreach (var item in command.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product == null)
                {
                    throw new BadRequestException($"Product with id {item.ProductId} not found");
                }

                var saleItem = new RO.DevTest.Domain.Entities.SaleItem(
                    sale.SaleId,
                    item.ProductId,
                    item.Quantity,
                    product.Price
                    )
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Sale = sale,
                    Product = product
                };

                sale.SaleItems.Add(saleItem);
            }

            // Calculate the total value of the sale
            sale.TotalValue = sale.SaleItems
                .Sum(x => x.Quantity * x.Product.Price);

            //Save the sale
            await _saleRepository.CreateAsync(sale);
            await _saleRepository.SaveAsync();

            //Create the response
            var saleResponse = new SaleResponse
            {
                SaleId = sale.SaleId,
                ClientName = string.Empty,
                SaleDate = sale.SaleDate,
                TotalAmount = sale.TotalValue,
                Items = sale.SaleItems.Select(x => new RO.DevTest.Application.Features.SaleItem.Command.SaleItemResponse
                {
                    ProductName = x.Product.ProductName,
                    Quantity = x.Quantity,
                    Price = x.Product.Price
                }).ToList()
            };

            return saleResponse;
        }
    }
}
