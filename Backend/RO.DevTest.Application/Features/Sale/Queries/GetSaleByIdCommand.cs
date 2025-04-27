using MediatR;
using RO.DevTest.Application.Features.Sale.Response;


namespace RO.DevTest.Application.Features.Sale.Queries
{
    public class GetSaleByIdCommand: IRequest<SaleResponse>
    {
        public Guid SaleId { get; set; }

        public GetSaleByIdCommand(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}
