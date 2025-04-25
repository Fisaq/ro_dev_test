namespace RO.DevTest.Domain.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public Guid SaleId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public float TotalValue { get; set; }

        public Client(string clientName, DateTime saleDate, float totalValue)
        {
            ClientId = Guid.NewGuid();
            SaleId = Guid.NewGuid();
            ClientName = clientName;
            SaleDate = saleDate;
            TotalValue = totalValue;
        }

        public void Update(string clientName, DateTime saleDate, float totalValue)
        {
            ClientName = clientName;
            SaleDate = saleDate;
            TotalValue = totalValue;
        }
    }
}
