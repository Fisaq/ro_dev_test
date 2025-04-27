namespace RO.DevTest.Domain.Entities
{
    public class SaleItem
    {
        public Guid SaleItemId { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float TotalValue { get; set; }
        public float UnitPrice { get; set; }

        public Sale Sale { get; set; }
        public Product Product { get; set; } 

        public SaleItem() { }

        public SaleItem(Guid saleId, Guid productId, int quantity, float unitprice)
        {
            SaleItemId = Guid.NewGuid();
            SaleId = saleId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitprice;
        }
    }
}
