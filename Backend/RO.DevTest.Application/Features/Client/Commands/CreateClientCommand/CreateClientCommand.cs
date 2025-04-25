using RO.DevTest.Application.Features.Client.Response;
using MediatR;

namespace RO.DevTest.Application.Features.Client.Commands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<ClientResponse>
    {
        public Guid ClientId { get; set; }
        public Guid SaleId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public float TotalValue { get; set; }
    }
}
