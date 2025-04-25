namespace RO.DevTest.Domain.Entities
{
    internal class SaleItem
    {
        public Guid SaleItemId { get; set; }
        public Guid ProductId { get; set; }
        public Guid SaleId { get; set; }
        public float TotalValue { get; set; }
        public SaleItem(Guid saleItemId, Guid productId, Guid saleId, int quantity, float price)
        {
            SaleItemId = saleItemId;
            ProductId = productId;
            SaleId = saleId;
            TotalValue = price * quantity;
        }
    }
}
