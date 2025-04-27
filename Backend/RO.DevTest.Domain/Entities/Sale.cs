namespace RO.DevTest.Domain.Entities
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime SaleDate { get; set; }
        public float TotalValue { get; set; }

        //Relationships between Sale and SaleItem
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

        public Sale(Guid clientId)
        {
            SaleId = Guid.NewGuid();
            ClientId = clientId;
            SaleDate = DateTime.UtcNow;
            TotalValue = 0;
        }
    }
}
