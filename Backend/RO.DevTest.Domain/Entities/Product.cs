namespace RO.DevTest.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }

        public Product(string productName, string productDescription, float price, int quantity)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            Quantity = quantity;
        }

        public void Update(string productName, string productDescription, float price, int quantity)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            Quantity = quantity;
        }
    }
}
