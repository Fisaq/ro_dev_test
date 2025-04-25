using MediatR;
using RO.DevTest.Application.Features.Client.Response;

namespace RO.DevTest.Application.Features.Client.Commands.UpdateClientCommand
{
    public class UpdateClientCommand : IRequest<ClientResponse>
    {
        public Guid ClientId { get; set; }
        public Guid SaleId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public float TotalValue { get; set; }
    }
}
