using RO.DevTest.Application.Features.SaleItem.Command;

namespace RO.DevTest.Application.Features.Sale.Response
{
    public class SaleResponse
    {
        public Guid SaleId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public float TotalAmount { get; set; }

        public List<SaleItemResponse> Items { get; set; } = new List<SaleItemResponse>();
    }
}
