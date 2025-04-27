using MediatR;
using RO.DevTest.Application.Features.SaleItem.Command;
using RO.DevTest.Application.Features.Sale.Response;
using RO.DevTest.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RO.DevTest.Application.Features.Sale.Commands
{
    public class CreateSaleCommand : IRequest<SaleResponse>
    {
        public DateTime Date { get; set; }
        public Guid ClientId { get; set; }
        public List<SaleItemCommand> Items { get; set; } = new List<SaleItemCommand>();

        public CreateSaleCommand(DateTime date,Guid clientId, List<SaleItemCommand> items)
        {
            Date = date;
            ClientId = clientId;
            Items = items;
        }
    }
}
