namespace RO.DevTest.Domain.Entities
{
    internal class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
