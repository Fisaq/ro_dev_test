using MediatR;
using RO.DevTest.Application.Features.Sale.Response;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;
using RO.DevTest.Application.Features.SaleItem.Command;
using Microsoft.EntityFrameworkCore;


namespace RO.DevTest.Application.Features.Sale.Queries
{
    public class GetAllSalesCommandHandler : IRequestHandler<GetAllSalesCommand, List<SaleResponse>>
    {
        private readonly ISaleRepository _saleRepository;

        public GetAllSalesCommandHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<SaleResponse>> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAllWithIncludeAsync(
                query => query
                    .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product),
                cancellationToken
             );

            if (sales == null || sales.Count == 0)
            {
                throw new BadRequestException("No sales found");
            }

            var saleResponses = sales.Select(sale => new SaleResponse
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
            }).ToList();

            return saleResponses;
        }
    }
}
