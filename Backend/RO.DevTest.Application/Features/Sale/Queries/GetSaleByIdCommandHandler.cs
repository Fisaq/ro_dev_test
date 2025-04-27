using MediatR;
using RO.DevTest.Application.Features.Sale.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;
using RO.DevTest.Application.Features.SaleItem.Command;

namespace RO.DevTest.Application.Features.Sale.Queries
{
    public class GetSaleByIdCommandHandler : IRequestHandler<GetSaleByIdCommand, SaleResponse>
    {
        private readonly ISaleRepository _saleRepository;
        public GetSaleByIdCommandHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public async Task<SaleResponse> Handle(GetSaleByIdCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.SaleId);

            if (sale == null)
            {
                throw new BadRequestException("Sale not found");
            }
            
            var saleResponse = new SaleResponse
            {
                SaleId = sale.SaleId,
                ClientName = "",
                SaleDate = sale.SaleDate,
                TotalAmount = sale.TotalValue,
                Items = sale.SaleItems.Select(x => new SaleItemResponse
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
