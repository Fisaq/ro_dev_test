namespace RO.DevTest.Domain.Entities
{
    internal class Client
    {
        public Guid ClientId { get; set; }
        public Guid SaleId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public float TotalValue { get; set; }
    }
}
