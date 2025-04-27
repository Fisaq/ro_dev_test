using MediatR;
using RO.DevTest.Application.Features.Sale.Response;

namespace RO.DevTest.Application.Features.Sale.Queries
{
    public class GetAllSalesCommand : IRequest<List<SaleResponse>>
    {
    }
}
