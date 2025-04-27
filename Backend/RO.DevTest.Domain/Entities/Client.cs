namespace RO.DevTest.Domain.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;


        public Client(string clientName)
        {
            ClientId = Guid.NewGuid();
            ClientName = clientName;
        }

        public void Update(string clientName)
        {
            ClientName = clientName;
        }
    }
}
